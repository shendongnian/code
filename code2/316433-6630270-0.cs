    public class MyContext : DbContext
    {
        public DbSet<Metrics> Metrics { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Metrics>().Property(x => x.PPM).HasPrecision(4, 3);
        }
    }
