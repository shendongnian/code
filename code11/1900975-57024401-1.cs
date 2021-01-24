    public class HomeController : Controller
    {
        private readonly IMyInterface _myinterface;
        public HomeController(IMyInterface myinterface)
        {
            _myinterface = myinterface;
        }
        public IActionResult Index()
        {
             var theWork = _myinterface.doMyWork();
        }
    }
