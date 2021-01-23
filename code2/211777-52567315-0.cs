     public static string IsActive(this HtmlHelper html,string control,string action)
        {
            var routeData = html.ViewContext.RouteData;
            var routeAction = (string)routeData.Values["action"];
            var routeControl = (string)routeData.Values["controller"];
            // both must match
            var returnActive = control == routeControl &&
                               action == routeAction;
            return returnActive ? "active" : "";
        }
