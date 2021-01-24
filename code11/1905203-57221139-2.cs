    using Serilog;
    public class MyController : Controller
    {
        private readonly ILogger _log;
    
        public MyController(ILogger log)
        {            
            _log = log;
        }
        public IActionResult Post(Address address)
        {
            _log.Information("Hello World!");
        }
    }
