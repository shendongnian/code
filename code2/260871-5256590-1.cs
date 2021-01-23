    public class HomeController: Controller
    {
    
        public ActionResult Index()
        {
            var model = Enumerable.Range(1, 20).Select(x => new MyViewModel
            {
                Id = x
            });
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(IEnumerable<MyViewModel> model)
        {
            ...
        }
    }
