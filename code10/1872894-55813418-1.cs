    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parent>().HasMany(x => x.Child1s).WithOne(x => x.Parent).HasForeignKey(x => x.ParentId);
            modelBuilder.Entity<Child1>().HasMany(x => x.Child2s).WithOne(x => x.Child1).HasForeignKey(x => x.Child1Id);
            this.InitialData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        protected void InitialData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parent>().HasData(new Parent[]
            {
                new Parent
                {
                    Id = 1,
                    Name = "Parent 1",
                }
            });
            modelBuilder.Entity<Child1>().HasData(new Child1[]
            {
                new Child1
                {
                    Id = 1,
                    Name = "Child 1 1",
                    ParentId = 1,
                }
            });
            modelBuilder.Entity<Child2>().HasData(new Child2[]
            {
                new Child2
                {
                    Id = 1,
                    Name = "Child 2 1",
                    Child1Id = 1
                }
            });
        }
        public DbSet<Parent> Parent { get; set; }
        public DbSet<Child1> Child1s { get; set; }
        public DbSet<Child2> Child2s { get; set; }
    }
