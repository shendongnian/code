    internal static string ReturnRedditJsonURI(string SubRedditName)
    {
    	return $"https://reddit.com/r/{SubRedditName}.json";
    }
    
    // Does a HTTP GET request to the external Reddit API to get contents and de-serialize it
    internal static async Task<JObject> ParseReddit(string SubRedditName)
    {
    	   string exampleURI = ReturnRedditJsonURI(SubRedditName);
    	   
    	   JObject response = new JObject();
    	   using (HttpClient client = new HttpClient())
    	   {
    			// Make the HTTP request now
    			HttpResponseMessage msg = await client.GetAsync(exampleURI);
    			
    			// If HTTP 200 then go ahead and de-serialize
    			if (msg.IsSuccessStatusCode)
    			{	
    				string responseBody = await msg.Content.ReadAsStringAsync();
    				response = JsonConvert.DeserializeObject<JObject>(responseBody);
    			}
    	   }
    	   return response;
    }
    	
    // Driver method to extract the URI(s) out of the reddit response
    internal static async Task<List<Uri>> GetRedditURI(string SubRedditName)
    {
    	string subRedditName = "Metallica";
    	JObject redditData = await ParseReddit(SubRedditName);
    	
    	List<Uri> redditURIList = new List<Uri>();
    	
    	try 
    	{
    		// TODO: instead of JObject use concrete POCO, but for now this seems to be it.
    		
    		redditURIList = redditData["data"]?["children"]?
    			.Select(x => x["data"])
    			.SelectMany(x => x)
                .Cast<JProperty>()
    			.Where(x => x.Name == "url")
    			.Select(x => x.Value.ToString())
    			.Select(x => new Uri(x, UriKind.Absolute)).ToList() ?? new List<Uri>();
    		
    		return redditURIList;
    	}
    	catch (Exception ex)
    	{
    		return redditURIList;
    	}
    }
