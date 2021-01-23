    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new AddPostViewModel()
            {
                Categories = Enumerable.Range(1, 5).Select(x => new SelectListItem
                {
                    Value = x.ToString(),
                    Text = "category " + x
                }),
                Post = new Post()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(AddPostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ...
            }
            ...
        }
    }
