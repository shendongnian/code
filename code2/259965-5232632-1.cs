    public class HomeController : ApplicationController
    {
        public ActionResult Index()
        {
            ViewBag.Modules = moduleRepository.GetAllModules();
            return View();
        }
    }
