    public async Task<HttpContent> InvokeApi(string path, HttpAction action, HttpContent content = null, TimeSpan? overrideTimeout = null, string externalServer = null)
    {
    
    	var sUrl = externalServer == null ? ServerUrl : externalServer;
    
    	using (var client = new HttpClient())
    	{
    		client.BaseAddress = new Uri(sUrl);
    		if (overrideTimeout.HasValue)
    		{
    			client.Timeout = overrideTimeout.Value;
    		}
    		//this.Log("Connecting to {0} Api at {1}".Fmt(WebPortalServer, ServerUrl));
    		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", AccessToken);
    		client.DefaultRequestHeaders.Accept.Clear();
    		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
    		HttpResponseMessage response;
    
    		switch (action)
    		{
    			case HttpAction.Get:
    				response = await client.GetAsync(path);
    				break;
    			case HttpAction.Post:
    				response = await client.PostAsync(path, content);
    				break;
    			case HttpAction.Put:
    				response = await client.PutAsync(path, content);
    				break;
    			case HttpAction.Delete:
    				response = await client.DeleteAsync(path);
    				break;
    			default:
    				throw new ArgumentOutOfRangeException("action", action, null);
    		}
    
    		return response.IsSuccessStatusCode ? response.Content : null;
    	}
    }
    
    public async Task<Common.Models.Yelp.Yelp> GetAllBusiness(decimal latitude, decimal longitude)
    {
    	HttpContent all = await _webPortalApiClient.InvokeApi($"businesses/search?limit=10&latitude={latitude}&longitude={longitude}", HttpAction.Get, null, null, "https://api.yelp.com/v3/");
    	if (all == null)
    	{
    		return null;
    	}
    
    	
    	string responseBody = await all.ReadAsStringAsync();
    	
    	// Deserialize from serialized string into your POCO
    	var business = JsonConvert.DeserializeObject<Common.Models.Yelp.Yelp>(responseBody);
    	return business;
    }
