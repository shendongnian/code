    public static class Helpers
    {
      public static Uri FullyQualifiedUri( this HtmlHelper html , string relativeOrAbsolutePath )
      {
        Uri        baseUri  = HttpContext.Current.Request.Url ;
        string     path     = UrlHelper.GenerateContentUrl( relativeOrAbsolutePath, new HttpContextWrapper( HttpContext.Current ) ) ;
        Uri        instance = null ;
        bool       ok       = Uri.TryCreate( baseUri , path , out instance ) ;
        return instance ; // instance will be null if the uri could not be created
      }
    }
