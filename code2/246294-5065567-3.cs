    public DataTable GetCurrentFxPrices(string url)
    {
        Uri uri = new Uri(url);
        WebClient webClient = new WebClient();
        IWebProxy defaultProxy = WebRequest.GetSystemWebProxy();
        IWebProxy myProxy = new WebProxy(new Uri("http://myproxy:8080"))
        // if no bypass-list is specified, all Uris are to be retrieved via proxy
    
        if (defaultProxy.IsBypassed(uri))
        {
            myProxy.Credentials = CredentialCache.DefaultCredentials;
            webClient.Proxy = myProxy;
        }            
    
        MemoryStream ms = new MemoryStream(webClient.DownloadData(url));
        DataSet ds = new DataSet("fxPrices");
        ds.ReadXml(ms);
        DataTable dt = ds.Tables["Rate"];
    
        int i = dt.Rows.Count;
        return dt;
    }
