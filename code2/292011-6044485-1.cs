    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SomeAction()
        {
            var model = new AggregatedModel
            {
                Model1 = new Model1(),
                Model2 = new Model2()
            };
            Response.ContentType = "text/javascript";
            return PartialView(model);
        }
    }
