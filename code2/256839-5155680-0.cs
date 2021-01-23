    var userAgent = HttpContext.Current.Request.UserAgent.ToLower();
    if (userAgent.Contains("iphone"))
    {
        // iPhone is there
    }
    else if (userAgent.Contains("ipad"))
    {
        // iPad is there
    }
    else
    {
        // something different
    }
