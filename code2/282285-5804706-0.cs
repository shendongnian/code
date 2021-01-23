    public class BaseRepo<S>
    {
        protected virtual DbSet<S> DefaultInclude(DbSet<S> set) {return set;}
    } 
    public class ProductRepo : BaseRepo<Product>
    {
        protected override DbSet<Product> DefaultInclude(DbSet<Product> set)
        {
           return set.Include("...");
        }
    }
