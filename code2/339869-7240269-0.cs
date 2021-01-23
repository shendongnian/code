        public static void RegisterRoutes(RouteCollection routes) 
        { 
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}"); 
 
          
            routes.MapRoute("ListBooks", 
              "Home/Books/{id}", 
              new { controller = "Home", action = "Books" }, 
              new { id = @"\d{2}" }); 
 
               routes.MapRoute( 
                "Default", // Route name 
                "{controller}/{action}/{id}", // URL with parameters 
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } 
            ); 
        } 
