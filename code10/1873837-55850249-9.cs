            IHttpClientFactory _clientFactory
            public BotController(..., IHttpClientFactory clientFactory, ...)
            {
                ...
                _clientFactory = clientFactory; 
                ...
            }
            [HttpPost]
            public async Task<IActionResult> Post([FromBody]Update update)
            {
                ...
                var request = new HttpRequestMessage(
                    HttpMethod.Get, 
                    "https://someaddress.com/api/resource");
                request.Headers.Add("Accept", "application/vnd.github.v3+json");
                request.Headers.Add("User-Agent", "YourApp");
                var client = _clientFactory.createClient();
                var response = await client.SendAsync(request);
                ...
            }
    
