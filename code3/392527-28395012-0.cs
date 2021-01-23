	public class RouteHandler : IRouteHandler
	{
		public RouteHandler()
		{
		}
		public RouteHandler(string virtualPath)
		{
		  _virtualPath = virtualPath;
		}
		public IHttpHandler GetHttpHandler(RequestContext requestContext)
		{
		    //Record the request context of the routing module in HttpContext.Current, so we can use it in pages.
		    HttpContext.Current.Items("requestContext") = requestContext
		    return BuildManager.CreateInstanceFromVirtualPath(_virtualPath, typeof(Page)) as IDisplay;
		}
		string _virtualPath;
	}
