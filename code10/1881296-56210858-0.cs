public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.LowercaseUrls = true;
            routes.MapRoute(
                name: "TrailersOverview",
                url: "{TrailersOverview}/{action}/{vendid}",
                defaults: new { controller = "TrailersOverview", action = "Index", vendId = UrlParameter.Optional }
            );
             routes.MapRoute(
                "MyCustomRoute", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "login", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
                name: "Default",
                url: "{*}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
And for the default route, I think you wanted to mention `{*}` for url to match everything else?
