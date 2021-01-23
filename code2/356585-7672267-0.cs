    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public IQueryable<Online> OnlineProducts
        {
            get
            {
                return Products.OfType<Online>();
            }
        }
        public IQueryable<Print> PrintProducts
        {
            get
            {
                return Products.OfType<Print>();
            }
        }
    }
