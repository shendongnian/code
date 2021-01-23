    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new[] 
            {
                new MyViewModel { Id = 1, IsChecked = false },
                new MyViewModel { Id = 2, IsChecked = true },
                new MyViewModel { Id = 3, IsChecked = false },
            };
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Index(IEnumerable<MyViewModel> model)
        {
            // TODO: Handle the user selection here
            ...
        }
    }
