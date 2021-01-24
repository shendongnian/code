    public static void RegisterRoutes(RouteCollection routes)
    {            
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
        routes.MapRoute("Hotel", "en/hotels/{hotelName}",
            new { controller = "Hotel", action = "index" });
        // Catch-all Route:
        routes.MapRoute("404-PageNotFound", "{*url}",
            new { controller = "YourController", action = "PageNotFound" } );
    }
