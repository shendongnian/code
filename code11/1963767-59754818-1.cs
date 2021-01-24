public class AppOptions
{
    public Dictionary<string, string>[] Tenants { get; set; }
}
public class TenantSecret
{
    public string ConnectionString { get; set; }
    public Guid Id { get; set; }
}
Then, configure the **AppOptions** class in the *Startup.cs* file (method **ConfigureServices**)
services.Configure<AppOptions>(Configuration);
Then, inject the **IOptions<AppOptions>** service in a controller constructor. Using this service, we will build the list of tenants you are looking for.
private readonly AppOptions _options;
private readonly List<Tenants> _tenants;
public HomeController(IOptions<AppOptions> options)
{
    _options = options.Value;
    _tenants = _options.Tenants.Select(t => t.GetTenant()).ToList();
}
You can notice a **GetTenant()** method above. It is an extension method called from an instance of **Dictionary<string, string>**, whose purpose is to convert a not pratical dictionary into an more practical instance of **TenantSecret**.
public static class TenantExtensions
{
    public static TenantSecret GetTenant(this Dictionary<string, string> helper)
    {
        TenantSecret tenant = new TenantSecret();
        foreach (var key in helper.Keys)
        {
            switch(key)
            {
                case "Id":
                    Guid.TryParse(helper[key], out var guid);
                    tenant.Id = guid;
                    break;
                case "ConnectionString":
                    tenant.ConnectionString = helper[key];
                    break;
            }
        }
        return tenant;
    }
}
  [1]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-3.1
