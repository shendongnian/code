    public class TestController : Controller
    {
        private readonly IOptionsMonitor<SomeOptions> _options;
        public TestController(IOptionsMonitor<SomeOptions> options)
        {
            _options = options;
        }
        [HttpGet]
        public async Task<IActionResult> GetConfig()
        {
            return Json(_options.CurrentValue); //returns recalculated value
        }
    }
