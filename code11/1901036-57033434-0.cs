    public static bool CheckActionPermission(string actionName, string controllerName, string areaName)
        {
            var accessUrl = string.Concat(areaName, "/", controllerName, "/", actionName);
            return ((CustomPrincipal)HttpContext.Current.User).Access.Any(a => a.Url == accessUrl);
        }
