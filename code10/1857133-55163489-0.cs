    public class FooService
    {
        private readonly HttpClient _httpClient;
        public FooService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        ...
    }
