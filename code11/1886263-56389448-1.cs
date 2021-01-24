    public class HomeController : Controller
    {
        private readonly MySpecialClassWithDependencies _mySpecialClassWithDependencies;
    
        public HomeController(MySpecialClassWithDependencies mySpecialClassWithDependencies)
        {
            _mySpecialClassWithDependencies = mySpecialClassWithDependencies;
        }
    
        public IActionResult Index()
        {
            // Now i can use my object here, the framework already initialized for me!
            return View();
        }
