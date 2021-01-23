    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel
            {
                Price = 0.56
            };
            return View(model);
        }
    }
