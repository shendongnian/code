    public static string GetExternalIP()
    {
	    try
	    {
		    using (WebClient client = new WebClient())
            {
		         string ip = client.DownloadString("http://whatismyip.com/automation/n09230945.asp");
                 return ip;
            }
	    }
	    catch (Exception) { return null; }
    }
