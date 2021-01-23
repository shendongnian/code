global.asax
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.IgnoreRoute("{*favicon}",
            new { favicon = @"(.*/)?favicon.ico(/.*)?" });
    
        routes.MapRoute(
            "Question-Answer", // Route name
            "{languageCode}/{controller}/{action}", // URL with parameters
            new {controller = "home", action = "index"} // Parameter defaults
            );
    
    }
