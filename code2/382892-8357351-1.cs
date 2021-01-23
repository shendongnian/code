    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel
            {
                Settings = new[] 
                {
                    new BoolSetting { DisplayName = "name 1", Value = true },
                    new BoolSetting { DisplayName = "name 2", Value = false },
                    new BoolSetting { DisplayName = "name 3", Value = true },
                }.ToList()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(MyViewModel model)
        {
            return View(model);
        }
    }
