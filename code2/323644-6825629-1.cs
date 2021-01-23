    private readonly string[] STATIC_CONTENT_PATHS = new string[] { "css", "js", "img" }; 
    public static void RegisterRoutes(RouteCollection routes)
    {    
        foreach (string path in STATIC_CONTENT_PATHS) { routes.IgnoreRoute(path + @"/{*foo}"); }
        // other MapRoute calls here
    }
