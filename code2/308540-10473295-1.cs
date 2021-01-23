    public class HomeController : Controller
    {       
        [HttpGet]
        public ActionResult Test()
        {
            ClassA ca = new ClassA();
            return View(ca);
        }
        [HttpPost]
        public ActionResult Test(ClassA ca)
        {            
            return View(ca);
        }
    }
