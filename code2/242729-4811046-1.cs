    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            return View(new MyViewModel
            {
                Name = "John"
            });
        }
    }
