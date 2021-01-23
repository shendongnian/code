            routes.MapRoute(
                "UsersRoute", // Route name
                "{username}", // URL with parameters
                new { controller = "Test", action = "Index", username = "" } 
            );
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } 
            );
