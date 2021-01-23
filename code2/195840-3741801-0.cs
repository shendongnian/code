    public interface MyRepository {
        IQueryable<Products> GetAllProducts();
        Product AddProduct(Product Product);
    }
    
    public class FakeRepository implements MyRepository {
        private static IList<Product> fakeProducts = new List<Product> {
