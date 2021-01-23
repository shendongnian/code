    public class RouteRegistrator : MvcTurbine.Routing.IRouteRegistrator
        {
            /// <summary>
            /// Registers routes within <see cref="T:System.Web.Routing.RouteCollection"/> for the application.
            /// </summary>
            /// <param name="routes">The <see cref="T:System.Web.Routing.RouteCollection"/> from the <see cref="P:System.Web.Routing.RouteTable.Routes"/>.</param>
            public void Register(System.Web.Routing.RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
                routes.MapRoute(
                    "Default", // Route name
                    "{controller}/{action}/{id}", // URL with parameters
                    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                    new string[] { "MyNamespace.Controllers" }); // Parameter defaults
            }
        }
