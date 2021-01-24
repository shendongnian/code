     public class ProductsController : ApiController
     {
        [Queryable]
        IQueryable<Product> Get() {
           var ef = new myDbContext(); 
           return ef.Products; // <-- DbSet<Product>
        }
     }
