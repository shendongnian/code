    namespace WebService
    {
        public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                // This is the key line
                config.EnableCors();
    
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            }
        }
    }
