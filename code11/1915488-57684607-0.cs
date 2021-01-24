    RootGlobalQuote rg = null;
    RootGlobalQuote rgOut = null;
    
    var response = _httpClient.GetAsync(GlobalQuoteUri);
    response.Wait();
    
    var resp = response.Result;
    
    if (resp.IsSuccessStatusCode)
    {
    	var outRg = resp.Content.ReadAsAsync<RootGlobalQuote>();
    	outRg.Wait();
    	rg = outRg.Result;
    	result = new RootGlobalQuote();
    }
