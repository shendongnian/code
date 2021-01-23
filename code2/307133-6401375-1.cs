    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new[]
            {
                new CanalViewModel { Name = "canal 1", Selected = false },
                new CanalViewModel { Name = "canal 2", Selected = true },
                new CanalViewModel { Name = "canal 3", Selected = false },
                new CanalViewModel { Name = "canal 4", Selected = false },
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(IEnumerable<CanalViewModel> model)
        {
            return View(model);
        }
    }
