        [Route("api/[controller]")]
        public class ThermostatController : Controller
        {
            public ThermostatController()
            {
            }
    
            [HttpGet, Route("GetTemp")]
            public int GetTemp()
            {
                return Ok(1);
            }
        }
