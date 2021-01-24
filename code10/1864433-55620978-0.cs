    public class TestController : Controller
    {
        private readonly IOptions<SomeOptions> _options;
        public TestController(IOptions<SomeOptions> options)
        {
            _options = options;
        }
        [HttpGet]
        public async Task<IActionResult> GetConfig()
        {
            return Json(_options.Value); //returns same value every time
        }
    }
