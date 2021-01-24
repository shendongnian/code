     public static class HtmlHelperExt
        {
            public static string IsSelected(this IHtmlHelper html, string controllers = "", string actions = "", string cssClass = "selected")
            {
                ViewContext viewContext = html.ViewContext;
                bool isChildAction = viewContext.ClientValidationEnabled;
    
                if (isChildAction)
                    viewContext = html.ViewContext;
    
                RouteValueDictionary routeValues = viewContext.RouteData.Values;
                string currentAction = routeValues["action"].ToString();
                string currentController = routeValues["controller"].ToString();
    
                if (String.IsNullOrEmpty(actions))
                    actions = currentAction;
    
                if (String.IsNullOrEmpty(controllers))
                    controllers = currentController;
    
                string[] acceptedActions = actions.Trim().Split(',').Distinct().ToArray();
                string[] acceptedControllers = controllers.Trim().Split(',').Distinct().ToArray();
    
                return acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController) ?
                    cssClass : String.Empty;
            }
    
            public static string ContentArea(this UrlHelper url, string path)
            {
                var modulName = url.ActionContext.RouteData.DataTokens["area"];
                string modulContentLoad = "";
    
                if (modulName != null)
    
                {
                    if (!string.IsNullOrEmpty(modulName.ToString()))
                        modulContentLoad = "Areas/" + modulName;
    
                    if (path.StartsWith("~/"))
                        path = path.Remove(0, 2);
    
                    if (path.StartsWith("/"))
                        path = path.Remove(0, 1);
    
    
                    path = path.Replace("../", string.Empty);
    
                    return VirtualPathUtility.ToAbsolute("~/" + modulContentLoad + "/" + path);
                }
    
                return string.Empty;
            }
        }
