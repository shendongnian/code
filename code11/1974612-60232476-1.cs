    using System.Threading.Tasks;
    using System.Net.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    
    namespace MyFunction.Function
    {
        public class Foo
        {
            private readonly HttpClient httpClient;
            public Scrape(IHttpClientFactory httpClientFactory)
            {
                factory = httpClientFactory;
            }
    
            [FunctionName("Foo")]
            public async Task<IActionResult> Run(
                [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
                ILogger log)
            {
                HttpClient httpClient = factory.CreateClient();
                var result = await httpClient.GetAsync("https://google.com");
                var data = await result.Content.ReadAsStringAsync();
                return new OkObjectResult(data);
            }
        }
    }
