    public void SMS(Uri address, string data)
    {
       // Perhaps string data is JSON, or perhaps its something delimited who knows.
       // Json seems to be the pretty lean.
    	try
    	{
    		HttpWebRequest request = (HttpWebRequest) WebRequest.Create(address);
    		request.Method = "POST";
            // If we don't setup proxy information then IE has to resolve its current settings
            // and adds 500+ms to the request time.
            request.Proxy = new WebProxy();
    		request.Proxy.IsBypassed(address);
    		request.ContentType = "application/json;charset=utf-8";
    		request.Headers.Add("X-Requested-With", "XMLHttpRequest");
    		StreamWriter writer = new StreamWriter(request.GetRequestStream());
    		writer.WriteLine(data);
    		writer.Close();
    		using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
    		{
    			using (Stream stream = response.GetResponseStream())
    			{
    				// Either read the stream or get the status code and description.
                    // Perhaps you won't even bother reading the response stream or the code 
                    // and assume success if no HTTP error status causes an exception.
    			}
    		}
    	}
    	catch (WebException exception)
    	{
    		if (exception.Status == WebExceptionStatus.ProtocolError)
    		{
    			// Something,perhaps a HTTP error is used for a failed SMS?
    		}
    	}
    }
