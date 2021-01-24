        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.RouteExistingFiles = true;
            routes.MapRoute("Hotel", "en/hotels/london/victoria/my_hotel_name/{*.*}",
                new { controller = "Hotel", action = "Index", }, namespaces: new[] { "UrlRouter.Router.Controllers" });
         }
