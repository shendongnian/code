cs
public class ApplicationDbContext : IdentityDbContext
{
    private readonly string _connectionString;
    public DbSet<Customer> Customers { get; set; }
    // and more DbSets are here ... 
    public ApplicationDbContext() : base()
    { }
    public ApplicationDbContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("LalalaDb");
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString, b => b.MigrationsAssembly("EntityFrameworkProject"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
