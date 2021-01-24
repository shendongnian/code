csharp
using MyNamespace.Functions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
[assembly: FunctionsStartup(typeof(Startup))]
namespace MyNamespace.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();
        }
    }
}
## Original Answer
Using the latest Azure Function v2 runtime, `IHttpClientFactory` is indeed available to you since the Azure Function v2 runtime has been moved to ASP.Net Core 2.2:
[Release v2.0.12265](https://github.com/Azure/azure-functions-host/releases/tag/v2.0.12265)
First, you can provide an implementation for `IWebJobsStartup` where you will define what services to inject. 
Add a reference to the NuGet package `Microsoft.Extensions.Http` and use the extension method `AddHttpClient()` so that the `HttpClient` instance your Azure Functions will receive will come from an `IHttpClientFactory`. 
csharp
using MyNamespace.Functions;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
[assembly: WebJobsStartup(typeof(Startup))]
namespace MyNamespace.Functions
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services.AddHttpClient();
        }
    }
}
You can then update your Azure Function by removing the `static` keywords and add a constructor to enable the injection of the instance of `HttpClient` built by the internal -I think- `DefaultHttpClientFactory` instance:
    public sealed class MyFunction()
    {
        private readonly HttpClient _httpClient;
        public MyFunction(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    
        public void Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/resource/{resourceId}")] HttpRequest httpRequest, string resourceId)
        {
             return OkObjectResult($"Found resource {resourceId}");
        }
    }
  [1]: https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection
