    static void Main(string[] args)
    {
    	var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
    	var request = new HttpRequestMessage
    	{
    		RequestUri = new Uri("https://postb.in/1559160461304-0137126960325"),
    		Method = HttpMethod.Post,
    	};
    
    	request.Headers.Add("username", "username");
    	request.Headers.Add("password", "password");
    
    	var httpResponse = client.SendAsync(request).Result;
    }
