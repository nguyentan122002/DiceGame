using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaiXiu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadomController : ControllerBase
    {
        [HttpGet("roll-dice")]
        public IActionResult GetRandomNumbers()
        {
            try
            {
                Random random = new Random();
                var numbers = new int[3];
                int total = 0;
                string result;

                for (int i = 0; i < 3; i++)
                {
                    numbers[i] = random.Next(1, 7); 
                    
                }

                for (int i = 0; i < numbers.Length; i++)
                {
                    total = total + numbers[i];
                }

                if (total < 11)
                {
                    result = "Xỉu";
                }
                else
                {
                    result = "Tài";
                }

                return Ok(new { DiceRolls = numbers, Total = total, Result = result }) ;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Lỗi hệ thống", Error = ex.Message });
            }
        }

        
    }
}
