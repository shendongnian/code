    routes.MapRoute(
    "Default", // Route name
    "{controller}/{action}/{id}", // URL with parameters
    new { controller = "Home", action = "Index", // Parameter defaults
    id = UrlParameter.Optional },
    new [] { "MyAppName.Controllers" } // Prioritized namespace
    );
