    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new Product { UnitPrice = 10.56m });
        }
        [HttpPost]
        public ActionResult Index(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            // TODO: the model is valid => do something with it
            return Content("Thank you for purchasing", "text/plain");
        }
    }
