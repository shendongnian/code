    namespace System.Web.Mvc.Html
    {
       public static class HtmlHelperExtensions
       {
          public static string ResolveUrl(this HtmlHelper html, string url)
          {
             var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
             return urlHelper.Content(url);
          }
       }
    }
