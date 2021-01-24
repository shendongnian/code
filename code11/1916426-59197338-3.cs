    public static class HttpConfigurationExtensions
    {
        public static void MapInheritedAttributeRoutes(this HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes(new InheritanceDirectRouteProvider());
        }
    }
     
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapInheritedAttributeRoutes();
            app.UseWebApi(config);
        }
    }
