    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class TestController : MyApiControllerBase
    {
        [HttpGet]      
        public IActionResult Get()
        {
            return Ok("Version 1.0 endpoint.");
        }
    }
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class TestController : MyApiControllerBase
    {
        [HttpGet]        
        public IActionResult Get()
        {
            return Ok("Version 2.0 endpoint.");
        }
    }
