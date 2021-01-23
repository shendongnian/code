    public static class LinkExtensions
    {
        public static MvcHtmlString MenuItem(
            this HtmlHelper htmlHelper,
            string linkText,
            string url,
            string requiredRole
        )
        {
            var a = new TagBuilder("a");
            a.Attributes["href"] = url;
            a.SetInnerText(linkText);
            if (string.IsNullOrEmpty(requiredRole))
            {
                // No role required => show the menu item
                return MvcHtmlString.Create(a.ToString());
            }
    
            var user = htmlHelper.ViewContext.HttpContext.User;
            if (!user.IsInRole(requiredRole))
            {
                // A role is required but no user authenticated or user is not in role
                // => show empty
                return MvcHtmlString.Empty;
            }
    
            // The user is in role => show the menu
            return MvcHtmlString.Create(a.ToString());
        }
    }
