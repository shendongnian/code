    public class JobsLedgerAPIContext : DbContext
    {
        // public DbSet<Job> Jobs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Integrated Security=SSPI;Initial Catalog=dotnetcore;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // may need to reflect entity classes and register them here.
            base.OnModelCreating(modelBuilder);
        }
    }
