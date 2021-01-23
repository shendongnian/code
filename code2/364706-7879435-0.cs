    using(var client = new WebClient())
    {
    	string authInfo = "admin:geoserver";
    	string address = "http://xxxxxxxx:8080/geoserver/rest/workspaces/";
    	client.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(authInfo));
    
    	var request = WebRequest.Create(address);
    
    	request.ContentType = "text/xml";
    	request.Method = "POST";
    
    	request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(authInfo));
    
    	byte[] bret = Encoding.GetEncoding("UTF-8").GetBytes("<workspace><name>" + nameWS + "</name></workspace>");
    
    	using (var reqstr = request.GetRequestStream())
    	{
    		reqstr.Write(bret, 0, bret.Length);
    	}
    
    	try
    	{
    		using (var response = request.GetResponse())
    		{
    			// your code here...
    		}
    
    	}
    	catch (Exception exc)
    	{
    		System.Diagnostics.Debug.WriteLine(exc.Message);
    	}
    }
