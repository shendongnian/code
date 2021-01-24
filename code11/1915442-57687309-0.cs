        public class SampleService : ISampleService
    {
        private readonly HttpClient _httpClient;
        public SampleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
