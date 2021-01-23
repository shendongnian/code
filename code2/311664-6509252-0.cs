    public static class UrlExtensions
    {
        public static string AbsoluteContent(this UrlHelper url, string contentPath)
        {
            var requestUrl = url.RequestContext.HttpContext.Request.Url;
            return string.Format(
                "{0}{1}",
                requestUrl.GetLeftPart(UriPartial.Authority),
                url.Content(contentPath)
            );
        }
    }
