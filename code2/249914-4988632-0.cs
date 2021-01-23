    routes.MapRoute(
            "ContentPages",
            "{id}",
            new { Area = "", controller = "Content", action = "Index" },
            new { id = new RootActionConstraint() }
            );
    routes.MapRoute(
            "Default", // Route name
            "{controller}/{action}/{id}",
            new { Area = "", controller = "Home", action = "Index", id = UrlParameter.Optional },
            new string[] { "Website.Controllers" }
        );
