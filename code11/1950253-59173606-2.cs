    public class MockCurrentUser : ICurrentUser
    {
        public string Name() => "Mock";
    }
    public class MockDbContext : DbContext, IMyDbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MockDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Staff> Staff { get; set; }
        public override int SaveChanges() => 1;
    }
