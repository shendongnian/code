       public class GoogleService
        {
            private readonly HttpClient httpClient;
    
            public GoogleService(HttpClient httpClient)
            {
                this.httpClient = httpClient;
            }
    
            public string GetBaseUrl()
            {
                return httpClient.BaseAddress.ToString();
            }
        }
