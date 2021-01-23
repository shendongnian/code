    public class DatabaseContext : DbContext
    {
        public DbSet<Membership.User> Users { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new TableSchemaConvention());
    
            base.OnModelCreating(modelBuilder);
        }
    }
