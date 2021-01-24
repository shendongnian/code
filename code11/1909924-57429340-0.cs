csharp
public override void Configure(IFunctionsHostBuilder builder)
{
    builder.Services.AddHttpClient();
    builder.Services.AddSingleton((s) => {
        return new CosmosClient(Environment.GetEnvironmentVariable("COSMOSDB_CONNECTIONSTRING"));
    });
    builder.Services.AddSingleton<ILoggerProvider, MyLoggerProvider>();
}
To use your HttpClient, you'll have to inject it to your functions class constructor:
csharp
public class MyFunc
{
    private readonly HttpClient _client;
    public MyFunc(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient();
    }
    [FunctionName("DoSomething")]
    public async Task<IActionResult> Get(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "do-something")] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");
        var res = await _client.GetAsync("my-cool-url.com);
        return new OkResult(res);
   }
}
What I especially like about this approach, is that you can create different keyed clients when you register it to the DI:
csharp
private void ConfigureService(IWebJobBuilder builder)
{
    // Some logic
    builder.Services.AddHttpClient("aaa", client =>
    {
        client.BaseAddress = new Uri("base-address.com");
    });
}
And then use it like this:
csharp
public MyFunc(IHttpClientFactory httpClientFactory)
{
    _client = httpClientFactory.CreateClient("aaa");
}
Let me know if something isn't working for you. :)
  [1]: https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection
