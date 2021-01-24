cs
public class SlackLoggerProvider
{
    private readonly IHttpClientFactory _clientFactory;
    public SlackLoggerProvider(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
}
You just need to add the `IHttpClientFactory` to your service collection:
cs
public void ConfigureServices(IServiceCollection services)
{
    ⋮
    services.AddHttpClient();
    ⋮
}
Reference: [Make HTTP requests using IHttpClientFactory in ASP.NET Core][1]
  [1]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests
