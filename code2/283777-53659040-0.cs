    public class Product
    {
        public long ProductID {get;set;}
    }
    
    public IEnumerable<Product> GetProductsByID(int[] prodIDs)
    {
        using (var context = new MyDatabaseContext())
        {
            return context.Products.Where(product => prodIDs.Contains(product.ProductID)); // ['System.Array' does not contain a definition for 'Contains'] error because product.ProductID is long and prodIDs is an array of ints.
        }
    }
