    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel
            {
                Name = "abc"
            };
            return View(model);
        }
    }
