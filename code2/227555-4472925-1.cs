    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        public ActionResult DoSomething(int a)
        {
            return View("Index");
        }
    }
