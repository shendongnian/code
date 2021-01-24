public class TestClient
{
    private HttpClient Client { get; }
    public TestClient(HttpClient client)
    {
        Client = client;
    }
    public Task<HttpResponseMessage> CallAsync(CancellationToken cancellation = default)
    {
        return client.GetAsync("/", cancellation);
    }
}
## Edit ##
(based on above edits)
If you want to override the default behavior of the `AddHttpClient` extension method, then you should register your implementation directly:
var services = new ServiceCollection();
services.AddHttpClient("test", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost");                    
});
services.AddScoped<TestClient>();
var servicesProvider = services.BuildServiceProvider(validateScopes: true);
using (var scope = servicesProvider.CreateScope())
{
    var client = scope.ServiceProvider.GetRequiredService<TestClient>();
}
public class TestClient
{
    private IHttpClientFactory ClientFactory { get; }
    
    public TestClient(IHttpClientFactory clientFactory)
    {
        ClientFactory = clientFactory;
    }
    public Task<HttpResponseMessage> CallAsync(CancellationToken cancellation = default)
    {
        using (var client = ClientFactory.CreateClient("test"))
        {
            return client.GetAsync("/", cancellation);
        }
    }
}
