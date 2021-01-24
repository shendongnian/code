        namespace Passenger.Tests.EndToEnd.Controllers
      {
         public class ControllerTestsBase
        {
        private readonly ITestServer _testServer;
        private readonly HttpClient Client;
        protected ControllerTestsBase(ITestServer testServer,HttpClient client)
        {
            _testServer = testServer;
             client.BaseAddress = new Uri("https://www.stackoverflow.com");
        
             client.DefaultRequestHeaders.Add("Accept","application/vnd.github.v3+json");
       
             client.DefaultRequestHeaders.Add("User-Agent","HttpClientFactory-Sample");
             Client = client;
        }
        protected static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            //Content-Type: "application/json"
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
