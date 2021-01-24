    public class HomeController : Controller
    {      
        private readonly IConfiguration _configuration;
        public HomeController IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index
        {
            var modelinstance = new FilteringRequest(_configuration);//create the viewmodel with default 'Type"
            return View();
        }
    }
