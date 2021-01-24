    public class MyDbContext : DbContext
    {
        public DbSet<MyEntity> MyEntity { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MyEntity>().HasNoKey(); // No key
        }
    }
