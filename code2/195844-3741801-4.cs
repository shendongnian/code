    public interface IRepository {
        IQueryable<Products> GetAllProducts();
        Product AddProduct(Product Product);
    }
    
    public class FakeRepository : IRepository {
        private static IList<Product> fakeProducts = new List<Product> {
            new Product{ ProductID = "xxx", Description = "xxx", Price = 1000},
            new Product{ ProductID = "yyy", Description = "xxx", Price = 2000},
            new Product{ ProductID = "zzz", Description = "xxx", Price = 3000}
         };
         public IQueryable<Product> GetAllProducts() {
             return fakeProducts.AsQueryable();
         }
         public Product Add(Product Product) {
             fakeProducts.Add(Product);
             return Product;
         }
     }
