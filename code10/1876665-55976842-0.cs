public abstract class BaseContext : DbContext
{
    public BaseContext(DbContextOptions options)
    : base(options)
    { }
    public DbSet<object> FirstSet { get; set; }
    ...
}
inherit from `BaseContext` for both DBs
public class LATAMContext : BaseContext
{
    public LATAMContext(DbContextOptions<LATAMContext> options) : base(options)
    {
    }
}
public class EUContext : BaseContext
{
    public EUContext(DbContextOptions<EUContext> options) : base(options)
    {
    }
}
and register both in `Startup.cs`
public IServiceProvider ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<LATAMContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LATAMConnectionString")));
    services.AddDbContext<EUContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EUConnectionString")));
    // Autofac
    var builder = new ContainerBuilder();
    // needed only if you plan to inject ICollection<BaseContext>
    builder.RegisterType<LATAMContext>().As<BaseContext>();
    builder.RegisterType<EUContext>().As<BaseContext>();
    builder.Populate(services);
    return new AutofacServiceProvider(builder.Build());
}
add connection strings in `appsettings.json`
"ConnectionStrings": {
  "LATAMConnectionString": "Server=(localdb)\\mssqllocaldb;Database=ContosoUniversity1;Trusted_Connection=True;MultipleActiveResultSets=true",
  "EUConnectionString": "Server=(localdb)\\mssqllocaldb;Database=ContosoUniversity1;Trusted_Connection=True;MultipleActiveResultSets=true"
}
and now you can inject both contexts
public class ReportRepository : IReportRepository
{
    private readonly LATAMContext latamDbContext;
    private readonly EUContext euDbContext;
    public ReportRepository(LATAMContext latamDbContext, EUContext euDbContext)
    {
        this.latamDbContext = latamDbContext;
        this.euDbContext = euDbContext;
    }
}
or if you plan to inject collection of contexts
public class ReportRepository : IReportRepository
{
    private readonly ICollection<BaseContext> dbContexts;
    public ReportRepository(ICollection<BaseContext> dbContexts)
    {
        this.dbContexts = dbContexts;
    }
}
to access specific context
var _euContext = dbContexts.FirstOrDefault(x => x is EUContext) as EUContext;
var _latamContext = dbContexts.FirstOrDefault(x => x is LATAMContext) as LATAMContext;
