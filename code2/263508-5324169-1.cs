    public class Product
    {
        ...
        public static Expression<Func<Product, bool>> IsOnSale
        {
            get
            {
                return p => (p.IsDiscontinued == false && p.UnitsInStock > 0);
            }
        }
    }
   
