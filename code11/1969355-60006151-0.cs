    public class YourClassName
    {
        private readonly HttpMessageHandler _httpMessageHandler;
    
        public YourClassName(HttpMessageHandler httpMessageHandler)
        {
            _httpMessageHandler = httpMessageHandler;
        }
    
        protected override async Task PopulateData()
        {
        	using (var client = new HttpClient(_httpMessageHandler))
        	{
        		var token = "private token";
        		var requestUrl = api_url_here;
        		var authenticatedRequestUrl = requestUrl + $"{token}";
        		var response = await client.GetAsync(authenticatedRequestUrl);
        		var stringResult = await response.Content.ReadAsStringAsync();
        
        		// do something
        	}
        }
    }
