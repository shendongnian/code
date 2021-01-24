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
            //Make sure you are using the variable you set up in this controller
            _log.Information**("Hello World!");
        }
    }
