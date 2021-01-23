    namespace MvcApp.Controllers
    {
        public class ProductController : Controller
        {
            DBContext dbContext = new DBContext();
    
            //
            // GET: /Product/
    
            public ViewResult List()
            {
                IEnumerable<Product> products = dbContext.Products;
                return View(products);
            }
    
        }
    }
