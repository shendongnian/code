    // "Internet Explorer is unable to open Office documents from an SSL Web site".
    // http://support.microsoft.com/kb/316431/en-us
    if (!context.Request.IsSecureConnection || !isInternetExplorer(context))
    {
        // No cache.
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        context.Response.AppendHeader(@"Pragma", @"no-cache");
    }
