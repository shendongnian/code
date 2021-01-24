    public class APIClient
    {
        private HttpClient _client;
    
        public APIClient()
        {
            _client = SetupClient();
        }
    
        private HttpClient SetupClient()
        {
            //setup your client here
            var client = new HttpClient();
    
            //string oauthToken = TokenService.GetUserToken();
            string oauthToken = "eyJhbGciO......."; //Example token
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {oauthToken}");
    
            //more setup here
    
            return client;
        }
    
        public async Task<HttpResponseMessage> Get(string endpoint)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
    
            return await CallAsync(request);
        }
    
        private async Task<HttpResponseMessage> CallAsync(HttpRequestMessage request)
        {
            //do things before?
    
            var result = await _client.SendAsync(request);
    
            //handle result? null? not success code?
    
            return result;
        }
    }
