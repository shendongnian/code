    public static string GetMediaPropertyUrl(this IPublishedContent thisContent, string alias, UmbracoHelper umbracoHelper = null)
    {
        string url = "";
        if (umbracoHelper == null)
            umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
        var property = thisContent.GetProperty(alias);
        string nodeID = property != null ? property.Value.ToString() : "";
        
        if (!string.IsNullOrWhiteSpace(nodeID))
        {
            //get the media via the umbraco helper
            var media = umbracoHelper.TypedMedia(nodeID);
            //if we got the media, return the url property
            if (media != null)
                url = media.Url;
        }
        return url;
    }
