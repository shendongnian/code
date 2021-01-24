    async Task<string> Post(string uri, Dictionary<string, string> parameters)
    {
    	HttpResponseMessage response = null;
    	try
    	{
    		using (var httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(30) })
    		{
    			response = await httpClient.PostAsync(uri, new FormUrlEncodedContent(parameters));
    			if (!response.IsSuccessStatusCode)
    				throw new Exception("post request failed.");
    
    			var content = response.Content.ReadAsStringAsync().Result;
    			if (string.IsNullOrWhiteSpace(content))
    				throw new Exception("empty response received.");
    
    			return content;
    		}
    	}
    	catch (Exception e)
    	{
    		throw new Exception(error);
    	}
    }
