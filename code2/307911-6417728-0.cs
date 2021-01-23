    string utmGifLocation = "http://www.google-analytics.com/__utm.gif";
    
    		// Construct the gif hit url.
    		string utmUrl = utmGifLocation + "?" +
    			"utmwv=" + Version +
    			"&utmn=" + GetRandomNumber() +
    			"&utmhn=" + HttpUtility.UrlEncode(domainName) +
    			"&utmr=" + HttpUtility.UrlEncode(documentReferer) +
    			"&utmp=" + HttpUtility.UrlEncode(documentPath) +
    			"&utmac=" + account +
    			"&utmcc=__utma%3D999.999.999.999.999.1%3B" +
    			"&utmvid=" + visitorId +
    			"&utmip=" + GetIP(GlobalContext.Request.ServerVariables["REMOTE_ADDR"]);
    
    		SendRequestToGoogleAnalytics(utmUrl);
    
    
    
    	private void SendRequestToGoogleAnalytics(string utmUrl)
    	{
    		try
    		{
    			WebRequest connection = WebRequest.Create(utmUrl);
    
    			((HttpWebRequest)connection).UserAgent = GlobalContext.Request.UserAgent;
    			connection.Headers.Add("Accepts-Language",
    				GlobalContext.Request.Headers.Get("Accepts-Language"));
    
    			using (WebResponse resp = connection.GetResponse())
    			{
    				// Ignore response
    			}
    		}
    		catch (Exception ex)
    		{
    			if (GlobalContext.Request.QueryString.Get("utmdebug") != null)
    			{
    				throw new Exception("Error contacting Google Analytics", ex);
    			}
    		}
    	}
