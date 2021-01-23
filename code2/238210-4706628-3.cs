    public class StackoverflowTestContext : DbContext
    {
        public DbSet<FruitBase> Fruits { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banana>().ToTable("Bananas");
        }         
    }
