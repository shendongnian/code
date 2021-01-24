    public class MyContext : DbContext
    {
        public DbSet<User> Users{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Ignore(b => b.IgnoredField);
        }
    }
