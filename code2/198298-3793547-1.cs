    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new CustomerModel());
        }
        [HttpPost]
        public ActionResult Index(CustomerModel model)
        {
            return View(model);
        }
    }
