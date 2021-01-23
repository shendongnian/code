    public static class ImageHtmlHelpers
    {
       public static string ImageUrlFor(this HtmlHelper helper, string imageFilename, ImageSizeFolderEnum imageSizeFolder)
       {
           UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
           if (!File.Exists(helper.ViewContext.HttpContext.Server.MapPath(String.Format("~/content/userimages/{0}/{1}", imageSizeFolder, imageFilename))))
           {
               return urlHelper.Content(String.Format("~/content/userimages/{0}/none.png", imageSizeFolder));
           }
           else
           {
               return urlHelper.Content(String.Format("~/content/userimages/{0}/{1}", imageSizeFolder, imageFilename));
           }
       }
    }
