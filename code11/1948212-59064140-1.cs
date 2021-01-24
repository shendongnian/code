csharp
public class TenantDbContextFactory : ITenantDbContextFactory 
{
       public TenantDbContext GetDbContext()
       {
             string country;
               // Read Request to identify correct tenant
             switch (country)
             {
                 case "SG":
                      return new TenantDbContext("connectionstring for Sg")
                break;
                 case "MY":
                      return new TenantDbContext("connectionstring for my")
                break;
             }
       }
}
csharp
public class TenantDbContext: DbContext
{
    public DbSet<Company> Companies { get; set; }
    public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
csharp
public class TenantUnitOfWork: ITenantUnitOfWork
{
    private readonly TenantDbContext tenantDbContext;
    public TenantUnitOfWork(ITenantDbContextFactory tenantDbContextFactory)
    {
        this.tenantDbContext= tenantDbContextFactory.GetDbContext();
    }
    public TenantDbContext  TenantDbContext  { get { return tenantDbContext; } }
    public CompanyRepository CompanyRepo { get { return new CompanyRepository(tenantDbContext); } }
    public void Dispose()
    {
        tenantDbContext.Dispose();
    }
}
csharp
public class CompanyRepository
{
    protected readonly TenantDbContext tenantDbContext ;
    public CompanyRepository(TenantDbContext tenantDbContext)
    {
        this.tenantDbContext = tenantDbContext ;
    }
    public async Task<List<Company>> GetCompanies()
    {
        List<Company> companies = new List<Company>();
        companies = await tenantDbContext.Companies.Where(x => x.Company_Status == "A" && x.Status == "0").ToListAsync();
        return companies;
    }
}
