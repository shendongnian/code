    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new DerviedViewModel
            {
                BaseProp = "base prop",
                DerivedProp = "derived prop"
            });
        }
    }
