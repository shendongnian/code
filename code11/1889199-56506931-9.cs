    void Main()
    {
    	var rootObj = Process<RootObject>("https://www1.oanda.com/rates/", "api/v2/rates/");
    }
    
    
    public TResponse Process<TResponse>(string host, string api)
    {
    	// Execute Api call
    	var httpResponseMessage = MakeApiCall(host, api);
    
    	// Process Json string result to fetch final deserialized model
    	return FetchResult<TResponse>(httpResponseMessage);
    }
    
    public HttpResponseMessage MakeApiCall(string host, string api)
    
    {
    	// Create HttpClient
    	var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }) { BaseAddress = new Uri(host) };
    	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
    	// Make an API call and receive HttpResponseMessage
    	HttpResponseMessage responseMessage = client.GetAsync(api, HttpCompletionOption.ResponseContentRead).GetAwaiter().GetResult();
    
    	return responseMessage;
    }
    
    public T FetchResult<T>(HttpResponseMessage result)
    {
    	if (result.IsSuccessStatusCode)
    	{
    		// Convert the HttpResponseMessage to string
    		var resultArray = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
    
    		// Json.Net Deserialization
    		var final = JsonConvert.DeserializeObject<T>(resultArray);
    
    		return final;
    	}
    	return default(T);
    }
