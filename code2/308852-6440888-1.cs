    List<string> distinctHosts = new List<string>();
    
    foreach (string url in UrlList)
    {
        Uri uri = new Uri(url)
        
        if (! disctinctHosts.Contains(uri.Host))
        {
            distinctHosts.Add(uri.Host);
        }
    }
