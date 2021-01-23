    public class MyRoute : Route
    {
        #region '----- Method(s) -----'
        public MyRoute(string url, object defaults)
            : base(url, new RouteValueDictionary(defaults), new MvcRouteHandler())
        { }
    
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            RouteData routeData = base.GetRouteData(httpContext);
    
            string domain = httpContext.Request.Url.Host;
    
            routeData.Values["domain"] = domain;
                    
            return routeData;
        }
        #endregion
    }
