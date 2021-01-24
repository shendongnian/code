    public class MyRefreshClient
    {
        private readonly HttpClient _httpClient;
        public MyRefreshClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        ...
    }
    public class MyHttpClient : IMyHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly MyRefreshClient _refreshClient;
        public MyHttpClient(HttpClient httpClient, MyRefreshClient refreshClient)
        {
            _httpClient = httpClient;
            _refreshClient = refreshClient;
        }
    }
