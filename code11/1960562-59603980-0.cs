csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<ProductContext>(o => o.UseInMemoryDatabase("test")); // this is just to prove a point, your EF setup will be different
    // register all your services here
    services.AddScoped<IUnitOfWork, UnitOfWork>(); // Scoped objects are the same within a request, but different across different requests. 
    services.AddTransient<LypProductRepository>(); // and so on and so forth...
    
    // your other initialisation code here
}
### UnitOfWork.cs
csharp
public class UnitOfWork : IUnitOfWork
{
    private readonly ProductContext _context;
    public ProductRepository ProductRepository { get; set; }
    public UnitOfWork(ProductContext context, ProductRepository productRepository, ...other repositories) // since you are registering your services in Startup.cs anyway, why not leverage DI here?
    {
        _context = context;
        ProductRepository = productRepository;
        // your other repositories
    }
    ...
}
