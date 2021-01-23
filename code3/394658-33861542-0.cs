    using System.Data.Services;
    using System.ServiceModel.Activation;
    using System.Web.Mvc;
    using System.Web.Routing;
    namespace <YourNamespace>
    {
        public class RouteConfig
        {
            public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
                routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                    // the controller should NOT contain "DataSourceService"
                    constraints: new { controller = "^((?!(DataSourceService)).)*$" }
                );
                routes.Add(new ServiceRoute("DataSourceService", new DataServiceHostFactory(), typeof(DataSourceService)));
            }
        }
    }
