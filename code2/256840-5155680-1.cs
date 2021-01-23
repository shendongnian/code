    var userAgent = HttpContext.Current.Request.UserAgent.ToLower();
    if (userAgent.Contains("iphone"))
    {
        // iPhone
    }
    else if (userAgent.Contains("ipad"))
    {
        // iPad
    }
    else
    {
        // Think Different ;)
    }
