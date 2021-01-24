    public class SomeFoo : IHasApiKey
    {
        private readonly string _apiKey;
        public SomeFoo(string apiKey)
        {
            _apiKey = apiKey;
        }
        
        public string ApiKey => _apiKey;
    }
