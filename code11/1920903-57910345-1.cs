c#
public void ConfigureServices(IServiceCollection services)
{
    // ...
    services.Configure<MyAppContext>(Configuration.GetSection(nameof(MyAppContext)));
    // ...
}
Define your class MyAppContext:
public class MyAppContext
{
    public MyAppContext()
    {
    }
    public string DefaultType { get; set; }
    // other public properties here...
}
In your FilteringRequest class:
c#
public class FilteringRequest
{
    private readonly MyAppContext _appContext;
    public FilteringRequest(Microsoft.Extensions.Options.IOptions<MyAppContext> appContext)
    {
        _appContext = appContext.Value;
    }
    string _type;
    public string Type
    {
        get => _type ?? (_type = _appContext.DefaultType);
        set => _type = value;
    }
    // ...
}
