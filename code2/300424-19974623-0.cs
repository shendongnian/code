    public class CustomRoute: RouteBase, IRouteWithArea
    {
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
             // Implement custom virtual path (url) here
        }
        #region IRouteWithArea Members
    
        public string Area
        {
            get { return "Store"; }
        }
    
        #endregion
    }
