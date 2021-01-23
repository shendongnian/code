    routes.MapRoute(
        "Blogs", // Route name
        "{blog}/{action}/{id}", // URL with parameters
        new { controller = "Blogs", action = "List", id = UrlParameter.Optional },
        new { blog = "(blogname1|blogname2|blogname3|etc)" }
    );
