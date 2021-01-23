    public class HomeController : Controller
    {
        private WebWidgetTestContext db = new WebWidgetTestContext();
    
        public ActionResult Index()
        {
            var model = db.Webpages.ToList();
                
            return View(model);
        }
    }
