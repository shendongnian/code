c#
public void ConfigureServices(IServiceCollection services)
{
    // ...
    // I suppose you have a class that implements IAppContext
    services.Configure<AppContext>(Configuration.GetSection(nameof(AppContext)));
    // ...
}
In your FilteringRequest class:
c#
public class FilteringRequest
{
    private readonly IAppContext appContext;
    public FilteringRequest(Microsoft.Extensions.Options.IOptions<AppContext> appContext)
    {
        appContext = appContext.Value;
    }
    string _type;
    public string Type
    {
        get => _type ?? (_type = appContext.DefaultType);
        set => _type = value;
    }
    // ...
}
Try this out and vote up if it works.
