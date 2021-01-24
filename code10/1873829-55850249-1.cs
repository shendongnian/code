            public BotController(..., IHttpClientFactory clientFactory, ...)
            {
                ...
                _httpClient = clientFactory.createClient("someClient");
                ...
            }
       
