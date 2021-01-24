    public class HomeController : Controller
    {
        private readonly IDetection _detection;
    
        public HomeController(IDetection detection)
        {
            _detection = detection;
        }
    
        public IActionResult Index()
        {
            string browser_information = _detection.Browser.Type.ToString() +
                                         _detection.Browser.Version;
            //...
        }
    } 
 
