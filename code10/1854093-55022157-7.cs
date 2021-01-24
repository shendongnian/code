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
