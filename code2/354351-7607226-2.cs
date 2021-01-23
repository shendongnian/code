    public static void RegisterRoutes(RouteCollection routes)
    {
    	routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    	routes.MapRoute(null, "home/product/{id}", new {
    			controller = "Home", action = "Index",
    			id = UrlParameter.Optional}
    	);
    	routes.MapRoute("Default",	// Route name
    			"{controller}/{action}/{id}",	// URL with parameters
    			new {
    			    controller = "Home", action = "Index",
    			    id = UrlParameter.Optional }	// Parameter defaults
    	);
    }
