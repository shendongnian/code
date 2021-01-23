    using System;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    namespace YourNameSpaceHere
    {
        public static class MenuExtensions
        {
            public static MvcHtmlString MenuItem(
                this HtmlHelper htmlHelper,
                string html,
                string action,
                string controller
            )
            {
                var li = new TagBuilder("li");
                var routeData = htmlHelper.ViewContext.RouteData;
                var currentAction = routeData.GetRequiredString("action");
                var currentController = routeData.GetRequiredString("controller");
                if (string.Equals(currentAction, action, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(currentController, controller, StringComparison.OrdinalIgnoreCase))
                {
                    li.AddCssClass("active");
                }
                //generate a unique id for the holder and convert it to string
                string holder = Guid.NewGuid().ToString();
                string anchor = htmlHelper.ActionLink(holder, action, controller).ToHtmlString();
                //replace the holder string with the html
                li.InnerHtml = anchor.Replace(holder, html);
                return MvcHtmlString.Create(li.ToString());
            }
        }
    }
