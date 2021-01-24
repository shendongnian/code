        //Startup.cs
        services.AddSingleton(Log.Logger);
        //Use
        public class HomeController : Controller
        {
            private readonly ILogger _logger;
            public HomeController(ILogger logger)
            {
                _logger = logger;
            }
            public IActionResult Index()
            {
                _logger.Information("Inform ILog from ILogger");
                return View();
            }        
        }
