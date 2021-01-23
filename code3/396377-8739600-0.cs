    public class Company
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
    }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new Company
            {
                Address = "some address",
                Email = "some email",
                Name = "some name",
                WebSite = "some website"
            };
            return View(new RouteValueDictionary(model));
        }
    }
