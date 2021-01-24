cs
.ConfigureLogging(builder =>
{
    builder.Services.AddSingleton<ILoggerProvider, SlackLoggerProvider>();
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
**UPDATE:**
The answer I provided above does cause a `StackOverflowException`. I believe this is due to this line:
https://github.com/aspnet/HttpClientFactory/blob/7c4f9479b4753a37c8b0669a883002e5e448cc94/src/Microsoft.Extensions.Http/DependencyInjection/HttpClientFactoryServiceCollectionExtensions.cs#L29
The code that is building the HttpClient is calling the code that is adding logging, which in this case is again calling the code that is building the HttpClient... until the stack overflows.
So it appears the approach you use in the question is probably the best way to do what you're trying to do, as it resolves everything before sending it to your logger.
