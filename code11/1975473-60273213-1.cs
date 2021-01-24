      public class YahooService
        {
            private readonly HttpClient httpClient;
    
            public YahooService(HttpClient httpClient)
            {
                this.httpClient = httpClient;
            }
    
            public string GetBaseUrl()
            {
                return httpClient.BaseAddress.ToString();
            }
        }
