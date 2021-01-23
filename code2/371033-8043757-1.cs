    var currentUrl = Session["CurrentUrl"] as string;
    if (!string.IsNullOrEmpty(currentUrl))
    {
    	try
    	{
    		var ip = new Uri(currentUrl);
    		var ipNoPort = string.Format("{0}://{1}/{2}", ip.Scheme, ip.Host, ip.PathAndQuery);
            return Redirect(ipNoPort);
    	}
    	catch (System.UriFormatException)
    	{
    		return Home()
    	}
    }
    else
    {
    		return Home();
    }
