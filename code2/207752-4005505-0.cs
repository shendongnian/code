    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel
            {
                Value = "foo"
            };
            return View(model);
        }
    }
