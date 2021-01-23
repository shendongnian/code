        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                return View(new ProjectViewModel());
            }
            [HttpPost]
            public ActionResult Index(ProjectViewModel model)
            {
                return View(model);
            }
        }
