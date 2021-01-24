    public class ProductsController : ODataController
    {
        // ...
        //code logic here
        // ...
    
        [HttpGet]
        [EnableQuery]
        public IQueryable<Product> Get()
        {
            var products = _context.Products;
    
            return products;
        }
    
        // ...
    
    }
