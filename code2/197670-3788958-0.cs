    public static class Helpers
        {
            public static MvcHtmlString CustomLink(this HtmlHelper helper,string LinkText, string actionName)
            {
                var rtvals = helper.ViewContext.RouteData.Values;
                var rtvals2 = helper.RouteCollection;
                RouteValueDictionary rv = new RouteValueDictionary();
                foreach (string param in helper.ViewContext.RequestContext.HttpContext.Request.QueryString.AllKeys) 
                {
                    rv.Add(param, helper.ViewContext.RequestContext.HttpContext.Request.QueryString[param]);
                }
                foreach (var k in helper.ViewContext.RouteData.Values) 
                {
                    rv.Add(k.Key, k.Value);
                }
                return helper.ActionLink(LinkText, actionName, rv);
            }
        }
