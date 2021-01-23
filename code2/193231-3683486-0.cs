    // Check if page is running under theperfectfajita.com. If not redirect ...
    if (!HttpContext.Current.Request.Url.Host.Contains("localhost"))
    {
        if (HttpContext.Current.Request.Url.Host.CompareTo("domain.com") != 0)
        {
            HttpContext.Current.Response.Redirect("http://www.domain.com" + Context.Request.Url.PathAndQuery);
        }
    }
