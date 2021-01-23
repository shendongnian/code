    public static void RegisterRoutes(RouteCollection routes)
    {
    		routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
    		
    		routes.MapRoute(
    				"TestRoute",
    				"{id}",
    				new { controller = "Product", action = "Index3", id = UrlParameter.Optional }
    		);
    		
    		routes.MapRoute(
    				"Default", // Route name
    				"{controller}/{action}/{id}", // URL with parameters
    				new { controller = "Home", action = "RsvpForm", id = UrlParameter.Optional } // Parameter defaults
    				//new { controller = "Product", action = "Index2", id = UrlParameter.Optional } // Parameter defaults
    		);
    
    
    		routes.MapRoute(
    				"TestRoute2",
    				"{action}",
    				new { controller = "Home", action = "Index", id = UrlParameter.Optional }
    		);
    
    }
