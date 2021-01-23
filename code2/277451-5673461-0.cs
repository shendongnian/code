    private static IEnumerable<HttpStatusCode> onlineStatusCodes = new[]
    {
    	HttpStatusCode.Accepted,
    	HttpStatusCode.Found,
    	HttpStatusCode.OK,
    	// add more codes as needed
    };
    
    private static bool IsSiteOnline(string url, int timeout)
    {
    	HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
    	{
    		if (request != null)
    		{
    			request.Method = "HEAD"; // get headers only
    			request.Timeout = timeout;
    			using (var response = request.GetResponse() as HttpWebResponse)
    			{
    				return response != null && onlineStatusCodes.Contains(response.StatusCode);
    			}
    		}
    	}
    	return false;
    }
