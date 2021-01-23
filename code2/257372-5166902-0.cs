    context.MapRoute(
        "Admin_default",
        "Admin/{controller}/{action}/{id}",
        new { controller = "Home", action = "Index", id = UrlParameter.Optional },
        new string[] { "MvcBase.Areas.Admin.Controllers" }
    );
