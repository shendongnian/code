    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
    
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
    
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }
