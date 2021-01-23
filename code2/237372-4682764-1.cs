    public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
                routes.IgnoreRoute("*.js|css|swf");
                routes.RouteExistingFiles = true;
    
                routes.MapRoute(
                   "VirtualTourConfig",
                   "virtualtour/config.xml",
                   new { controller = "VirtualTour", action = "Config" }
                   );
    }
