    private async Task<WrapperHttpResponse> RestGetCachedAsync(string query, ILogger logger = null)
        {
            string key = $"GET:{query}";
            WrapperHttpResponse response;
            var cacheResponse = await _cacheService.GetStringValue(key);
            if (cacheResponse != null)
            {
                response = JsonConvert.DeserializeObject<WrapperHttpResponse>(cacheResponse, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    NullValueHandling = NullValueHandling.Ignore,
                });
                if(response.HttpResponseMessage.IsSuccessStatusCode) return response;
            }
            response = await RestGetAsync(query, logger);
            if (response.HttpResponseMessage.IsSuccessStatusCode)
            {
                await _cacheService.SetStringValue(key, JsonConvert.SerializeObject(response, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    NullValueHandling = NullValueHandling.Ignore,
                }));
            }            
            return response;
        }
