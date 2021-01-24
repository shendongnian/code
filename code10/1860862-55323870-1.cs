    namespace MyApp.Namespace1
    {
        [Area("Catalog")]
        public class ProductsController : Controller
        {
            public IActionResult AddProduct()
            {
                return View();
            }        
        }
    }
