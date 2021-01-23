    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var city = new City
            {
                RegEx = "[0-9]{5}"
            };
            return View(city);
        }
        [HttpPost]
        public ActionResult Index(City city)
        {
            return View(city);
        }
    }
