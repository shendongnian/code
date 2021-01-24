     public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: 
    "api/{controller}/{name}",
                defaults: new { name = RouteParameter.Optional }
            );
        }
