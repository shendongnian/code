            public class ProductEqualityComparer : IEqualityComparer<Product>
            {
                public bool Equals(Product x, Product y)
                {
                    return x.Id == y.Id;
                }
    
                public int GetHashCode(Product obj)
                {
                   return obj.Id.GetHashCode();
                }
            }
    
            static void Main(string[] args)
            {
    
                HashSet<Product> allUniqueProducts = 
                    new HashSet<Product>(new ProductEqualityComparer());
            
