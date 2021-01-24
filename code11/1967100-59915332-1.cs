    public class ExpandedViewEngine : RazorViewEngine
    {
        public ExpandedViewEngine()
        {
            var thirdPartySubfolders = new[] 
            {
                "~/Areas/B2b/Views/Shopify/{1}/{0}.cshtml"
            };
            ViewLocationFormats = ViewLocationFormats.Union(thirdPartySubfolders).ToArray();
            // use the following if you want to extend the partial locations
            // PartialViewLocationFormats = PartialViewLocationFormats.Union(new[] { "new partial location" }).ToArray();
            // use the following if you want to extend the master locations
            // MasterLocationFormats = MasterLocationFormats.Union(new[] { "new master location" }).ToArray();   
        }
    }
