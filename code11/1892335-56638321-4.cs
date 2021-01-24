    class RedirectRouteHandler : IRouteHandler
    {
        private readonly string _routeName;
            
        public RedirectRouteHandler(string routeName)
        {
            _routeName = routeName;
        }
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new RedirectHandler(this._routeName, requestContext.RouteData.Values);
        }
    }
    class RedirectHandler : IHttpHandler
    {
        private readonly string _routeName;
        private readonly RouteValueDictionary _routeValues;
        public RedirectHandler(string routeName, RouteValueDictionary routeValues)
        {
            this._routeName = routeName;
            this._routeValues = routeValues;
        }
        public bool IsReusable { return false; }
        public void ProcessRequest(HttpContext context)
        {
            context.Response.RedirectToRoute(this._routeName, this._routeValues);
        }
    }
