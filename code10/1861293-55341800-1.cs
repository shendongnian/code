    public class MyHttpClient : IMyHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly HttpClient _refreshClient;
        public MyHttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyHttpClient");
            _refreshClient = httpClientFactory.CreateClient("MyRefreshClient");
        }
    }
