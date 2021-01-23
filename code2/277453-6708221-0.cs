    static bool isOnline (string URL)
    {
    	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
    	request.Timeout = 3000;
    
    	try
    	{
    		WebResponse resp = request.GetResponse();
    	}
    	catch (WebException e)
    	{
    		if (((HttpWebResponse)e.Response).StatusCode == HttpStatusCode.NotFound)
    		{
    			return false;
    		}
    	}
    
    	return true;
    }
