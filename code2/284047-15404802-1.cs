    public static string ResolveRelative(string url)
    {
        var requestUrl = context.Request.Url;
        string baseUrl = string.Format("{0}://{1}{2}{3}", 
            requestUrl.Scheme, requestUrl.Host, 
            (requestUrl.IsDefaultPort ? "" : ":" + requestUrl.Port), 
            context.Request.ApplicationPath);
    
        if (toresolve.StartsWith("~"))
        {
            return baseUrl + toresolve.Substring(1);
        }
        else
        {
            return new Uri(new Uri(baseUrl), toresolve).ToString();
        }
    }
