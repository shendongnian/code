    public static class HtmlHelpers {
        public static MvcHtmlString ActionLinkWithTitle(this HtmlHelper helper, 
                                                        string linkText, 
                                                        string actionName, 
                                                        object routeValues) {
           return helper.ActionLink(linkText, actionName, routeValues, 
                  new {title = Url.Action(linkText, actionName, routevalues )
        }
    }
