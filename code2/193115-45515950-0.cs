    public static string ConvertToAbsoluteUrl(string url)
    {
		if (!IsAbsoluteUrl(url))
		{
			if (HttpContext.Current != null && HttpContext.Current.Request != null && HttpContext.Current.Handler is System.Web.UI.Page)
			{
				var originalUrl = HttpContext.Current.Request.Url;
				return string.Format("{0}://{1}{2}{3}", originalUrl.Scheme, originalUrl.Host, !originalUrl.IsDefaultPort ? (":" + originalUrl.Port) : string.Empty, ((System.Web.UI.Page)HttpContext.Current.Handler).ResolveUrl(url));
			}
			throw new Exception("Invalid context!");
		}
        else
            return url;
    }
    private static bool IsAbsoluteUrl(string url)
    {
        Uri result;
        return Uri.TryCreate(url, UriKind.Absolute, out result);
    }
