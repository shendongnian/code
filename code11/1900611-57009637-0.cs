    [ApiVersion("1.0")]
    [ApiController]
    [Route("/")]
    public class V1Controller : ControllerBase
    {
        [HttpGet("something")]
        public string Something() => "V1";
    }
    
    [ApiVersion("2.0")]
    [ApiController]
    [Route("/")]
    public class V2Controller : ControllerBase
    {
        [HttpGet("something")]
        public string Something() => "V2";
    }
