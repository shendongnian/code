    public static string GetAbsoluteUrl(string url)
    {
        //VALIDATE INPUT
        if (String.IsNullOrEmpty(url))
        {
            return String.Empty;
        }
        //VALIDATE INPUT FOR ALREADY ABSOLUTE URL
        if (url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        { 
            return url;
        }
        //GET CONTEXT OF CURRENT USER
        HttpContext context = HttpContext.Current;
        //RESOLVE PATH FOR APPLICATION BEFORE PROCESSING
        if (url.StartsWith("~/"))
        {
            url = (context.Handler as Page).ResolveUrl(url);
        }
        //BUILD AND RETURN ABSOLUTE URL
        string port = (context.Request.Url.Port != 80 && context.Request.Url.Port != 443) ? ":" + context.Request.Url.Port : String.Empty;
        return context.Request.Url.Scheme + Uri.SchemeDelimiter + context.Request.Url.Host + port + "/" + url.TrimStart('/');
    }
