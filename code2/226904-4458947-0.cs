    public interface ICategory
    {
        IList<Product> Products { get; }
    }
    
    public class Category : ICategory
    {
        IList<Product> ICategory.Products { get { return Products ; } }
        public List<Product> Products { get { ...actual implementation... } }        
    }
