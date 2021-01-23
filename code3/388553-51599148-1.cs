    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.WebPages;
    using JetBrains.Annotations;
    public static class AjaxExtensions
    {
        public static IHtmlString MyActionLink(
            this AjaxHelper ajaxHelper,
            Func<dynamic, HelperResult> linkHtml,
            [AspMvcAction] string actionName,
            AjaxOptions ajaxOptions
        )
        {
            var targetUrl = UrlHelper.GenerateUrl(null, actionName, null, null, ajaxHelper.RouteCollection, ajaxHelper.ViewContext.RequestContext, true);
            return MvcHtmlString.Create(ajaxHelper.GenerateLink(linkHtml, targetUrl, ajaxOptions ?? new AjaxOptions(), null));
        }
        public static IHtmlString MyActionLink(
            this AjaxHelper ajaxHelper,
            Func<dynamic, HelperResult> linkHtml,
            [AspMvcAction] string actionName,
            object routeValues,
            AjaxOptions ajaxOptions
        )
        {
            System.Web.Routing.RouteValueDictionary routeVals = new System.Web.Routing.RouteValueDictionary(routeValues);
            var targetUrl = UrlHelper.GenerateUrl(null, actionName, null, routeVals, ajaxHelper.RouteCollection, ajaxHelper.ViewContext.RequestContext, true);
            return MvcHtmlString.Create(ajaxHelper.GenerateLink(linkHtml, targetUrl, ajaxOptions ?? new AjaxOptions(), null));
        }
        private static string GenerateLink(
            this AjaxHelper ajaxHelper,
            Func<dynamic, HelperResult> linkHtml,
            string targetUrl,
            AjaxOptions ajaxOptions,
            IDictionary<string, object> htmlAttributes
        )
        {
            var a = new TagBuilder("a")
            {
                InnerHtml = linkHtml(null).ToString()
            };
            a.MergeAttributes(htmlAttributes);
            a.MergeAttribute("href", targetUrl);
            a.MergeAttributes(ajaxOptions.ToUnobtrusiveHtmlAttributes());
            return a.ToString(TagRenderMode.Normal);
        }
    }
