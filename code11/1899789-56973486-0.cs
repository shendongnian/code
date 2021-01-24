c#
class Program
{
    public static ServiceCollection AppServices { get; set; }
    public static void Main(string[] args)
    {
        // ...other stuff...
        AppServices = GetServiceCollection(config);
        // ...other stuff...
    }
    // renamed from GetServiceProvider
    private static ServiceCollection GetServiceCollection(IConfiguration config)
    {
        var collection = new ServiceCollection();
        // ... register services...
        return collection;
    }
}
Then in the `Startup` class, use `Program.AppServices` in `ConfigureServices()` as follows:
c#
public class Startup
{
    // ... other members ...
    public void ConfigureServices(IServiceCollection services)
    {
        // ... the usual stuff like services.AddMvc()...
        // add this line:
        services.TryAdd(Program.AppServices);
    }
    // ... other members ...
}
