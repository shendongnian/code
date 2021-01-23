    public interface IRepository
    {
        int CountProduct();
    }
    
    // your implementation of repository against real database
    public class DBLinqToSQLRepository : IRepository
    {
        // some constructor here
            
        public int CountProduct()
        {
            // your code here to return the actual number of product from db.
        }
    }
    // your implementation of fake repository that will provide fake data for testing
    public class FakeRepository : IRepository
    {
        private List<Product> products = new List<Product>();
        // some initialization here
        public int CountProduct()
        {
            return products.Count;
        }
    }
