    public class HomeController
    {
        private readonly MyService _myService;
        public HomeController(MyService myService)
        {
            _myService = myService;
        }
        public IActionResult Index()
        {
            _myService.SetSomeSessionValue("test");
            return View();
        }
    }
