    [Route("api/values")]
    public class ValuesController : ControllerBase
    {
        [ApiVersion("1.0")
        public IActionResult GetV1()
        {
        }
        [ApiVersion("2.0")]
        public IActionResult GetV2()
        {
        }
        // and so on ..
    }
