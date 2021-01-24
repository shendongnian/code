    [ApiVersion("1.0")
    [ApiVersion("2.0")]
    [Route("api/values")]
    public class ValuesController : ControllerBase
    {
        [MapToApiVersion("1.0")]
        public IActionResult GetV1()
        {
        }
        
        [MapToApiVersion("2.0")]
        public IActionResult GetV2()
        {
        }
        // and so on ..
    }
