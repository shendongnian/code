    public static class AjaxExtensions
    {
        public static IHtmlString MyActionLink(
            this AjaxHelper ajaxHelper,
            string linkText,
            string actionName,
            AjaxOptions ajaxOptions
        )
        {
            var targetUrl = UrlHelper.GenerateUrl(null, actionName, null, null, ajaxHelper.RouteCollection, ajaxHelper.ViewContext.RequestContext, true);
            return MvcHtmlString.Create(ajaxHelper.GenerateLink(linkText, targetUrl, ajaxOptions ?? new AjaxOptions(), null));
        }
        public static IHtmlString MyActionLink(
            this AjaxHelper ajaxHelper,
            string linkText,
            string actionName,
            object routeValues,
            AjaxOptions ajaxOptions
        )
        {
            System.Web.Routing.RouteValueDictionary routeVals = new System.Web.Routing.RouteValueDictionary(routeValues);
            var targetUrl = UrlHelper.GenerateUrl(null, actionName, null, routeVals, ajaxHelper.RouteCollection, ajaxHelper.ViewContext.RequestContext, true);
            return MvcHtmlString.Create(ajaxHelper.GenerateLink(linkText, targetUrl, ajaxOptions ?? new AjaxOptions(), null));
        }
        private static string GenerateLink(
            this AjaxHelper ajaxHelper,
            string linkText,
            string targetUrl,
            AjaxOptions ajaxOptions,
            IDictionary<string, object> htmlAttributes
        )
        {
            var a = new TagBuilder("a")
            {
                InnerHtml = linkText
            };
            a.MergeAttributes<string, object>(htmlAttributes);
            a.MergeAttribute("href", targetUrl);
            a.MergeAttributes<string, object>(ajaxOptions.ToUnobtrusiveHtmlAttributes());
            return a.ToString(TagRenderMode.Normal);
        }
    } 
 
