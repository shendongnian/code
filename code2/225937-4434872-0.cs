    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapRoute(
            "Anuncios",                 // Route name
            "Anuncios/{category}",      // URL with parameters
            new { category = "Index" }  // Parameter defaults
        );
    }
