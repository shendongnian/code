    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute(
            "Culture",
            "{culture}",
            new { controller = "Home", action = "Culture" },
            new { culture = @"^[a-z]{2}-[a-z]{2}$" }
        );
        routes.MapRoute(
            "Default",
            "{controller}/{action}/{id}",
            new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
    }
