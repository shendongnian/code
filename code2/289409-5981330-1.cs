    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel
            {
                Title = Titles.Other
            };
            return View(model);
        }
    }
