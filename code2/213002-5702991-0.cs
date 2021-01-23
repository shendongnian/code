    using System.Collections.Specialized;
    using Hammock;
    using System.Net;
    
    static class Server {
    	private static RestClient Client;
    	private static NameValueCollection Cookies;
    	private static string ServerUrl = "http://www.yourtarget.com/api"; 
    	
    	private static RestResponse _Request(RestRequest request) {
    		//If there was cookies on our accumulator...
    		if (Cookies != null)
    		{
    			// inyect them on the request
    			foreach (string Key in Cookies.AllKeys)
    			request.AddCookie(new Uri(ServerUrl), Key, Cookies[Key]);
    		}
    		
    		// make the request
    		RestResponse response = Client.Request(request);
    		
    		// if the Set-Cookie header is set, we have to save the cookies from the server.
    		string[] SetCookie = response.Headers.GetValues("Set-Cookie");
    		
    		//check if the set cookie header has something
    		if (SetCookie.Length > 0)
    		{
    			// if it has, save them for future requests
    			Cookies = response.Cookies;
    		}
    		
    		// return the response to extract content
    		return response;
    	}
    }
