    using System;
    using Microsoft.AspNet.Mvc.Rendering;
    
    public static class MenuExtensions
    {
        public static IHtmlContent MenuItem(
            this IHtmlHelper htmlHelper,
            string text,
            string action,
            string controller
        )
        {
            var li = new TagBuilder("li") { TagRenderMode = TagRenderMode.Normal };
            var routeData = htmlHelper.ViewContext.RouteData;
            var currentAction = routeData.Values["action"].ToString();
            var currentController = routeData.Values["controller"].ToString();
            if (string.Equals(currentAction, action, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(currentController, controller, StringComparison.OrdinalIgnoreCase))
            {
                li.AddCssClass("active");
            }
            
            li.InnerHtml.AppendHtml(htmlHelper.ActionLink(text, action, controller));
            return li;
   
        }
    }
