    public class MyRoute : Route
    {
        public MyRoute(string url, object defaults)
            : base(url, new RouteValueDictionary(defaults), new MvcRouteHandler())
        { }
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var rd = base.GetRouteData(httpContext);
            var tokens = httpContext.Request.Url.Host.Split('.');
            if (tokens.Length > 1)
            {
                rd.Values["username"] = tokens[0];
            }
            return rd;
        }
    }
