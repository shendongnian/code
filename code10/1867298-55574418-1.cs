    public class MyService : IMyInterface
    {
        private readonly HttpClient _client;
    
        public MyService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("MyServiceProxy1");
        }
    
        public async Task CallHttpEndpoint()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "www.customUrl.com");
            var response = await _client.SendAsync(request);
            ...
        }
    }
