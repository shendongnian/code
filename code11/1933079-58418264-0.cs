 c#
public interface IConfigurationProvider
{
    Task<Configuration> GetConfigurationAsync();
}
public sealed class DatabaseConfigurationProvider : IConfigurationProvider
{
    private readonly DbContext _dbContext;
    public DatabaseConfigurationProvider(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Configuration Configuration { get; set; }
    public async Task<Configuration> GetConfigurationAsync()
    {
         if (Configuration is null)
         {
             await // read configurations
         }
         return Configuration;
    }
}
Notice the public `Configuration` on the `DatabaseConfigurationProvider` implementation, which is *not* on the `IConfigurationProvider` interface. 
This is the core of the solution I'm presenting. Allow your [Composition Root][1] to set the value, without polluting your application abstractions, as application code doesn't need to overwrite the `Configuration` object; only the Composition Root needs to.
With this abstraction/implementation pair, the background service can look like this:
 c#
class MyBackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory; // set in ctor
    public Task DoStuff()
    {
        var itens = GetItens();
        
        // Create a scope for the root operation.
        using (var scope = _scopeFactory.CreateScope())
        {
            // Resolve the IConfigurationProvider first to load
            // the configuration once eagerly.
            var provider = scope.ServiceProvider
                .GetRequiredService<IConfigurationProvider>();
            
            var configuration = await provider.GetConfigurationAsync();
            Parallel.ForEach(itens, (item) => Process(configuration, item));
        }
    }
    
    private void Process(Configuration configuration, Item item)
    {
        // Create a new scope per thread
        using (var scope = _scopeFactory.CreateScope())
        {
            // Request the configuration implementation that allows
            // setting the configuration.
            var provider = scope.ServiceProvider
                .GetRequiredService<DatabaseConfigurationProvider>();
            
            // Set the configuration object for the duration of the scope
            provider.Configuration = configuration;
            // Resolve an object graph that depends on IConfigurationProvider.
            var service = scope.ServiceProvider.GetRequiredService<ItemService>();
            
            service.Process(item);
        }    
    }
}
To pull this off, you need the following DI configuration:
 C#
services.AddScoped<DatabaseConfigurationProvider>();
services.AddScoped<IConfigurationProvider>(
    p => p.GetRequiredService<DatabaseConfigurationProvider>());
This previous configuration registers `DatabaseConfigurationProvider` twice: once for its concrete type, once for its interface. The interface registration forwards the call and resolves the concrete type directly. This is a special 'trick' you have to apply when working with the MS.DI container, to prevent getting two separate `DatabaseConfigurationProvider` instances inside a single scope. That would completely defeat the correctness of this implementation.
  [1]: https://freecontent.manning.com/dependency-injection-in-net-2nd-edition-understanding-the-composition-root/
