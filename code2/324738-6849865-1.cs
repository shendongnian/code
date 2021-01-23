    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel
            {
                DisplayDate = DateTime.Now
            };
            return View(model);
        }
    }
