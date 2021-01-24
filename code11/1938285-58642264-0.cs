csharp
public class AccountAdminTest
{
    private readonly HttpClient _client;
    private IServiceScopeFactory scopeFactory;
    private readonly CustomWebApplicationFactory<Startup> _factory;
    private ApplicationDbContext _context;
    public AccountAdminTest(CustomWebApplicationFactory<Startup> factory)
    {
        //
        _factory = new CustomWebApplicationFactory<Startup>();
        _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = true,
            BaseAddress = new Uri("https://localhost:44444")
        });
        scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
        _scope = scopeFactory.CreateScope();
        _context = scope.ServiceProvider.GetService<ApplicationDbContext>();
    }
    //Tests...
    public void Dispose() {
        _scope.Dispose();
        _factory.Dispose();
        //Dispose and cleanup anything else...
    }
}
Alternatively you can specify a lifetime of `ServiceLifetime.Transient` for your `DbContext` [using this overload of `.AddDbContext`](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.entityframeworkservicecollectionextensions.adddbcontext?view=efcore-3.0#Microsoft_Extensions_DependencyInjection_EntityFrameworkServiceCollectionExtensions_AddDbContext__1_Microsoft_Extensions_DependencyInjection_IServiceCollection_Microsoft_Extensions_DependencyInjection_ServiceLifetime_Microsoft_Extensions_DependencyInjection_ServiceLifetime_)
