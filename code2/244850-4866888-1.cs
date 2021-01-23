    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = Enum.GetValues(typeof(ReferrerType)).Cast<ReferrerType>().Select(x => new MyViewModel
            {
                ReferrerType = x,
                Text = x.ToDescription() // I guess that's an extension method you wrote
            });
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(IEnumerable<MyViewModel> model)
        {
            ...
        }
    }
