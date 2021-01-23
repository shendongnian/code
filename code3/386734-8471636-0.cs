    routes.MapRoute(
        "", 
        "Admin/{controller}/{action}/{id}",
        new { controller = "Home", action = "Index", id = UrlParameter.Optional },
        new[] { "AppName.Areas.Admin.Controllers" }
    );
