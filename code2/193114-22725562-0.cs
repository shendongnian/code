     public class UrlUtils
        {
            public enum UrlMapOptions
            {
                AlwaysNonSSL,
                AlwaysSSL,
                BasedOnCurrentScheme
            }
    
            public static string MapUrl(string relativeUrl, UrlMapOptions option = UrlMapOptions.BasedOnCurrentScheme)
            {
                if (relativeUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                    relativeUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                    return relativeUrl;
    
                if (!relativeUrl.StartsWith("~/"))
                    throw new Exception("The relative url must start with ~/");
    
                UrlHelper theHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
    
                string theAbsoluteUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) +
                                               theHelper.Content(relativeUrl);
    
                switch (option)
                {
                    case UrlMapOptions.AlwaysNonSSL:
                        {
                            return theAbsoluteUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase)
                                ? string.Format("http://{0}", theAbsoluteUrl.Remove(0, 8))
                                : theAbsoluteUrl;
                        }
                    case UrlMapOptions.AlwaysSSL:
                        {
                            return theAbsoluteUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase)
                                ? theAbsoluteUrl
                                : string.Format("https://{0}", theAbsoluteUrl.Remove(0, 7));
                        }
                }
    
                return theAbsoluteUrl;
            }
        }   
