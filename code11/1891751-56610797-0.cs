    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class VersionDemoController
    {
        [ApiVersion("1.1")]
        [HttpGet("requestStuff")]
        public string RequestStuff()
        {
            return "Stuff using Version 1.1 API";
        }
    }
