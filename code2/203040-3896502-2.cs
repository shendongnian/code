    public class LookupRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            IRouteHandler handler = new MvcRouteHandler();
            var vals = requestContext.RouteData.Values;
            if(String.IsNullOrEmpty(vals["controller"])
            {
               // fetch action and controller from database
               vals["controller"] = dbcontroller;
               vals["action"] = dbaction;
            } 
            return handler.GetHttpHandler(requestContext);
        }
    }
