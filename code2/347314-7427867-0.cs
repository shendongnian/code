    string data = null;
    if (HttpContext.Cache[KeyTwitterData] == null)
    {
        var url = LinqToTwitter.Request.Url;
        data = ServiceMethods.GetConversation(url);
        HttpContext.Cache.Insert(KeyTwitterData, data);
    }
    else
    {
        data = (string)HttpContext.Cache[KeyTwitterData];
    }
