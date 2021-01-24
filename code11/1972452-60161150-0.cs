    public class TestController : ControllerBase
    {
    
        private readonly ILogger<TestController > logger;
    
        public TestController(ILogger<TestController > _logger)
        {
            logger = _logger;
        }
    
    
        [HttpGet]
        public string Test()
        {
            logger.LogInformation("Called Test/Test controller method");
    
            return "ok";
        }
    }
