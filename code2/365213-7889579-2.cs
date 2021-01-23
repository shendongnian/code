    public static void redirectIfNotServer(string redirectUrl)
    {
    	// Look for a proxy address first
    	var IP = HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR");
    	//Trim and lowercase IP if not null
    	if ((IP != null)) {
    		IP = IP.ToLower().Trim;
    	}
    	if (IP == null || (IP.Equals("unknown"))) {
    		//If IP is null use different detection method, else pull the correct IP from list.
    		IP = HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").ToLower().Trim();
    	}
    
    	List<string> IPs = null;
    	if (IP.IndexOf(",") > -1) {
    		IPs = IP.Split(',').ToList();
    	} else {
    		IPs = new string[] { IP }.ToList();
    	}
    
    	var serverIP = HttpContext.Current.Request.ServerVariables("LOCAL_ADDR");
    	var ipIsServerIp = (from ipAddress in IP swhere ipAddress == serverIP).Any();
    	if (!ipIsServerIp) {
    		HttpContext.Current.Response.Redirect(redirectUrl);
    	}
    }
