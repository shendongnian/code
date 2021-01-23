     public static class UrlExtensions
        {
            public static string ActionWithoutParam(this UrlHelper helper, string action, string evilParam)
            {
                if (helper.RequestContext.RouteData.Values.ContainsKey(evilParam))
                {
                    helper.RequestContext.RouteData.Values.Remove(evilParam);
                }
    
                return helper.Action(action);
            }
        }
