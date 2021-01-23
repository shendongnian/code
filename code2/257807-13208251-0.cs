    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var featuredProduct = new Product
            {
                Name = "Smart Phone",
                QtyOnHand = 12
            };
        
            ViewData["FeaturedProduct"] = featuredProduct;
            return View();
        }
    }
