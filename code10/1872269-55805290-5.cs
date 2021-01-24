        public class HomeController : Controller
        {
            private readonly ILoggingService _loggingService;
            public HomeController(ILoggingService loggingService)
            {
                _loggingService = loggingService;
            }
            public IActionResult Index()
            {
                var result = _loggingService.Output();
                return View();
            }        
        }
