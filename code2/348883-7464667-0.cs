    private bool testRequest(string urlToCheck)
    {
    	var wreq = (HttpWebRequest)WebRequest.Create(urlToCheck);
    
    	//wreq.KeepAlive = true;
    	wreq.Method = "HEAD";
    
    	HttpWebResponse wresp = null;
    
    	try
    	{
    		wresp = (HttpWebResponse)wreq.GetResponse();
    
    		return (wresp.StatusCode == HttpStatusCode.OK);
    	}
    	catch (Exception exc)
    	{
    		System.Diagnostics.Debug.WriteLine(String.Format("url: {0} not found", urlToCheck));
    		return false;
    	}
    	finally
    	{
    		if (wresp != null)
    		{
    			wresp.Close();
    		}
    	}
    }
