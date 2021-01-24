    private async Task<MyObject> Sample(string requestUri)
    {
        try{
            var client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(60)
            };
        
            var response = await client.GetStringAsync(requestUri);
    
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
    
            return JsonConvert.DeserializeObject<MyObject>(response, settings);
        }
        catch(HttpRequestExceptions ex){
    
            return default;
        }
    }
