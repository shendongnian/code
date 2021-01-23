    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new MyViewModel());
        }
        [HttpPost]
        public ActionResult Index(MyViewModel model)
        {
            // TODO : process the model ...
            return Json(new { Result = "Success" });
        }
    }
