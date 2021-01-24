cs
public class RouteConfig
{
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "RouteOverwrite",
                url: "data/{*catchall}",
                defaults: new { controller = "Data", action = "Index" }
            );
        }
}
Make sure you use this in `Application_Start`:
cs
public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
// register route config
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
