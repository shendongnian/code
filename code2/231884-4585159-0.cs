    NetworkCredential nc = new NetworkCredential("SITEUSERNAME", "SITEPASSWORD");
    CredentialCache cache = new CredentialCache();
    cache.Add(new Uri(RSSFeed), "Basic", nc);
    cache.Add(new Uri(RSSFeed), "Ntlm", new NetworkCredential("USERNAME","PASSWORD","DOAMIN"));
    HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(RSSFeed);
    myHttpWebRequest.Credentials = cache;
