    public sealed class MyFunction()
    {
        private readonly HttpClient _httpClient;
        public MyFunction(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    
        public void Run([HttpTrigger]...)
        {
        }
    }
