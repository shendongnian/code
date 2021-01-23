    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new[]
            {
                new MyViewModel { Key = "key1", Value = 15.4 },
                new MyViewModel { Key = "key2", Value = 16.1 },
                new MyViewModel { Key = "key3", Value = 20 },
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(IEnumerable<MyViewModel> items)
        {
            return View(items);
        }
    }
