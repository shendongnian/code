    public interface ICategory<out T> where T:IList<Product>
        {
            T Product { get; }
        }
        
    public class Category : ICategory<List<Product>>
        {
            public List<Product> Products
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
        } 
