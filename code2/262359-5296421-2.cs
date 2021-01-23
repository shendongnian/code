    routes.MapRoute(
        "CustomJs", // Route name
        "Js/Variables", // URL with parameters
        new { controller = "DynamicScripts", action = "JsVariables", id = UrlParameter.Optional } // Parameter defaults
    );
