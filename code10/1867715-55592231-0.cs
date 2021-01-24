    public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
            routes.MapRoute(
              name: "Main",
              url: "{deptID}/{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "Index", deptID = "", id = UrlParameter.Optional }
          );
    
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
