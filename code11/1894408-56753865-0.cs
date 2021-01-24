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
