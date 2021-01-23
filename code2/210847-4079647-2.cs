    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel
            {
                Interval = TimeSpan.FromDays(1)
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(MyViewModel model)
        {
            // The model will be properly bound here
            return View(model);
        }
    }
