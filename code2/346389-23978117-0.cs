	public static class UrlExtensions
	{
		public static string Content(this UrlHelper urlHelper, string contentPath, bool toAbsolute = false)
		{
			var path = urlHelper.Content(contentPath);
			var url = new Uri(HttpContext.Current.Request.Url, path);
			return url.AbsoluteUri;
		}
	}
