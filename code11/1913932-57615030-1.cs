     public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Date()
        {
           return View("Date");
        }
        public IActionResult Location()
        {
            doSomethingFunction();
            return View("Location");
        }
    }
