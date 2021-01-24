    public class ApiClient
    {
        private readonly HttpClient _client;
        public ApiClient(HttpClient client)
        {
            _client = client;
        }
        ...
    }
