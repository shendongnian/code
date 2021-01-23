    using (((WindowsIdentity)HttpContext.Current.User.Identity).Impersonate())
    {
    	WebClient client = new WebClient
    	   {
    		Credentials = CredentialCache.DefaultNetworkCredentials
    	   };
    	string result = client.DownloadString("http://someserver");
    }
