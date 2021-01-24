    [Route("api/[controller]")]
     [ApiController]
     public class AngularTestController : ControllerBase
     {
        [HttpGet("{formattedNumber}/{vin}")]
        public int CheckIfIDExists(int formattedNumber, string vin) 
        {
            return 0;
        }
     }
