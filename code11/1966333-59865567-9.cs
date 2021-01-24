    public class SomeClass
    {
        private HttpClient _client;
        public SomeClass(HttpClient client)
        {
            _client = client;
        }
        public async Task GetStuffFromAPI(string requestUrl)
		{
            await _client.GetAsync(reqestUrl);();
        }
