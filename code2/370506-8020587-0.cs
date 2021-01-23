    public RequestClass(String proxyURL, int port, String username, String password)
    {
        //Validate proxy address
        var proxyURI = new Uri(string.Format("{0}:{1}", proxyURL, port));
        //Set credentials
        ICredentials credentials = new NetworkCredential(username, password);
        //Set proxy
        this.proxy =  = new WebProxy(proxyURI, true, null, cred);
    }
