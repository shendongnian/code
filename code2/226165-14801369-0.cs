    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        // register the report routes
        // the second RouteValueDictionary sets the constraint that {controller} = "reports"
        routes.MapPageRoute("ReportTest",
            "{controller}/test",
            "~/WebForms/test.aspx",
            false,
            new RouteValueDictionary(),
            new RouteValueDictionary { { "controller", "reports"} });
        routes.MapRoute(
            "Default", // Route name
            "{controller}/{action}/{id}", // URL with parameters
            new { controller = "Home", action = "Index", id = UrlParameter.Optional } 
        );
    }
