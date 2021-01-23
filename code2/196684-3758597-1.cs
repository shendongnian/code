    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new MyModel
            {
                Item = new Item { Date = DateTime.Now }
            });
        }
    }
