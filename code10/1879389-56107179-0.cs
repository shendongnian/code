    Timer timer = new Timer(async (state) =>
    {
    	string feedback = "";
    	try
    	{
    		var uriOfAPI = new Uri("http://httpbin.org/post");
    		using (WebClient webClient = new WebClient())
    		{
    			webClient.Headers["ContentType"] = "application/json";
    			feedback = await webClient.UploadStringTaskAsync(uriOfAPI, "POST", "whatever the input should be");
    		}
    	}
    	catch (Exception)
    	{
    		// how you are going to handle when API malfunction
    	}
    
    	// feedback convert to json(in this example, it already is)
    
    	File.WriteAllText(@".\output.txt", feedback);
    
    }, null, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(10));
