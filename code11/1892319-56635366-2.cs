    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
    
    CookieContainer cookieContainer = new CookieContainer();
    Uri baseUri = new Uri("https://www.digikey.com");
    
    using (HttpClientHandler handler = new HttpClientHandler() { CookieContainer = cookieContainer })
    using (HttpClient client = new HttpClient(handler) { BaseAddress =  baseUri})
    {
    	//The User-Agent is required (what values work would need to be tested)
    	client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:67.0) Gecko/20100101 Firefox/67.0");
    
    	//Make our initial junk request that will fail but get the cookie
    	HttpResponseMessage getCookiesResponse = await client.GetAsync("/product-search/download.csv");
    
    	//Check if we actually got cookies
    	if (cookieContainer.GetCookies(baseUri).Count > 0)
    	{
    		//Try getting the data
    		HttpResponseMessage dataResponse = await client.GetAsync("product-search/download.csv?FV=ffe00035&quantity=0&ColumnSort=0&page=4&pageSize=500");
    
    		if(dataResponse.StatusCode == HttpStatusCode.OK)
    		{
    			Console.Write(await dataResponse.Content.ReadAsStringAsync());
    		}
    	}
    	else
    	{
    		throw new Exception("Failed to get cookies!");
    	}
    }
