        routes.MapRoute(
        "Static Routes",
        "",
        new { controller = "Home", action = "Index" }
        );
        routes.MapRoute(
        "Identities",
        "{identity}",
        new { controller = "Identity", action = "Index" }
        );
       routes.MapRoute(
        "Default", // Route name
        "{controller}/{action}/{id}", // URL with parameters
        new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
        );
