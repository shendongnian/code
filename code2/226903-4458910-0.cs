    public interface ICategory
    {
        IList<Product> Products { get; }
    }
    public class Category : ICategory
    {
        // Return IList<Product>, not List<Product>
        public IList<Product> Products { get { new List<Product>(); } }        
    }
