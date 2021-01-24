using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace WebApi1
{
    public class OtherWsClient
    {
        private readonly HttpClient _client;
        public OtherWsClient(HttpClient client)
        {
            _client = client;
        }
        public async Task<string> SendRequest()
        {
            var content = new StringContent(
                "{\"Key\":\"\",\"Order\":{\"DeliveryDate\":\"5/1/2020\",\"OrderLines\":[{\"ItemNr\":\"12345\",\"Quantity\":1,\"Description\":\"Some string\",\"QuantityPerUnit\":1}],\"Tries\":0}, \"Customernr\":\"123\"}",
                Encoding.UTF8,
                "application/json");
            var response = await _client.PostAsync("/otherwsapi", content);
            response.EnsureSuccessStatusCode();
            var responseConent = await response.Content.ReadAsStringAsync();
            return responseConent;
        }
    }
}
Then you need to tell framework about new `OtherWs` client in Startup class.
Example:
        public void ConfigureServices(IServiceCollection services)
        {
            .....
            services.AddHttpClient<OtherWsClient>((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri("base url");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "secret token");
            });
        }
The only thing left is to inject the new client and use it in your main controller.
Example:
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace WebApi1.Controllers
{
    public class MyWsController : ControllerBase
    {
        private readonly OtherWsClient _otherWsClient;
        public MyWsController(OtherWsClient otherWsClient)
        {
            _otherWsClient = otherWsClient;
        }
        public async Task<IActionResult> Post()
        {
            var response = await _otherWsClient.SendRequest();
            return Content(response);
        }
    }
}
