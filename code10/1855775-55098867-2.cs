    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute(
            name: "Assign",
            url: "App/{action}/{id}",
            defaults: new { controller = "App", action = "Assign", id = UrlParameter.Optional }               
        );
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }
        );
    }
