    public string WebRequestinJson(string url, string postData)
    {
    	string ret = string.Empty;
    
    	StreamWriter requestWriter;
    
    	var webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
    	if (webRequest != null)
    	{
    		webRequest.Method = "POST";
    		webRequest.ServicePoint.Expect100Continue = false;
    		webRequest.Timeout = 20000;
    
    		webRequest.ContentType = "application/json";
    		//POST the data.
    		using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
    		{
    			requestWriter.Write(postData);
    		}
    	}
    
    	HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
    	Stream resStream = resp.GetResponseStream();
    	StreamReader reader = new StreamReader(resStream);
    	ret = reader.ReadToEnd();
    
    	return ret;
    }
