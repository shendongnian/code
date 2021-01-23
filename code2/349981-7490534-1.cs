    public static void RegisterRoutes(RouteCollection routes)
    {
        // ...
        routes.MapRoute(
            "ImageRedirects", "images/{filename}", 
            new { controller = "Image", filename = "" });
        // ...
    }
