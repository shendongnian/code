    public class Context : DbContext
    {
        // Helper for example
        // DO NOT USE IN REAL SCENARIOS!!!
        private static int i = 0; 
        public DbSet<MyEntity> MyEntities { get; private set; }
        public Context()
            : base("connection")
        {
            MyEntities = Set<MyEntity>();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MyEntity>().HasKey(e => e.Id);
            // Turn off autogeneration in database
            modelBuilder.Entity<MyEntity>()
                        .Property(e => e.Id)
                        .HasDatabaseGenerationOption(DatabaseGenerationOption.None);
            // Other mapping
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<MyEntity>()
                .Where(e => e.State == EntityState.Added))
            {
                // Here you have to add some logic to generate Id
                // I'm using just static field
                entry.Entity.Id = ++i;  
            }
            return base.SaveChanges();
        }
    }
    public class MyEntity
    {
        public int Id { get; set; }
        // Other properties
    }
