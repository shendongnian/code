            public static string GetCurrentWebsiteRoot()
            {
                return HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
    
            }
