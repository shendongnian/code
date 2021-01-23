    public class P
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string CategoryId { get; set; }
    }
    public class C
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class ProductsContext : DbContext
    {
        public DbSet<P> Products { get; set; }
        public DbSet<C> Categories { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<P>().HasRequired(p => p.CategoryId).WithRequiredDependent();
        }
    }
