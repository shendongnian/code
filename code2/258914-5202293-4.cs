    public static class ImageHtmlHelpers
    {
       public static string ImageUrlFor(this HtmlHelper helper, string imageFilename, ImageSizeFolderEnum imageSizeFolder)
       {
           UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
           string contentUrl = String.Format("~/content/userimages/{0}/{1}", imageSizeFolder, imageFilename);
           if (!File.Exists(helper.ViewContext.HttpContext.Server.MapPath(contentUrl)))
           {
               return urlHelper.Content(String.Format("~/content/userimages/{0}/none.png", imageSizeFolder));
           }
           else
           {
               return urlHelper.Content(contentUrl);
           }
       }
    }
