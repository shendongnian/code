    public async Task<TResponse> Process<TResponse>(string host,string api)
    {
	   // Execute Api call Async
	   var httpResponseMessage = await MakeApiCall(host,api);
	   // Process Json string result to fetch final deserialized model
	   return await FetchResult<TResponse>(httpResponseMessage);
    } 
    public async Task<HttpResponseMessage> MakeApiCall(string host,string api)
    
    {	
    	// Create HttpClient
    	var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }) { BaseAddress = new Uri(host) };
    	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    	
    	// Make an API call and receive HttpResponseMessage
    	HttpResponseMessage responseMessage = await client.GetAsync(api, HttpCompletionOption.ResponseContentRead);
    	
    	return responseMessage;
    }
    
    public async Task<T> FetchResult<T>(HttpResponseMessage result)
    {
    	if (result.IsSuccessStatusCode)
    	{
    		// Convert the HttpResponseMessage to string
    		var resultArray = await result.Content.ReadAsStringAsync();
    
    		// Json.Net Deserialization
    		var final = JsonConvert.DeserializeObject<T>(resultArray);
    
    		return final;
    	}
    	return default(T);
    }
