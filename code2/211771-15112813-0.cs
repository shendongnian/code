    public static class HtmlHelpers
    {
        public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper,
                                                string linkText,
                                                string actionName,
                                                string controllerName
                                            )
        {
            string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
            if (actionName.Equals(currentAction, StringComparison.InvariantCultureIgnoreCase) && controllerName.Equals(currentController, StringComparison.InvariantCultureIgnoreCase))
            {
                return htmlHelper.ActionLink(linkText, actionName, controllerName, null, new { @class = "active" });
            }
            return htmlHelper.ActionLink(linkText, actionName, controllerName);
        }
    }
 
