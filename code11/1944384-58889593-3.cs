cs
.ConfigureLogging(builder =>
{
    builder.Services.AddScoped<ILoggerProvider, SlackLoggerProvider>();
})
Then you can use dependency injection as usual:
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
**UPDATE**: Changing from `AddSingleton` to `AddScoped`.
