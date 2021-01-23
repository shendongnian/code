    routes.MapRoute(
                    "ProductsList",
                    "{controller}",
                    new { controller = "Home", action = "Index" }
                    );
    
                routes.MapRoute(
                    "ProductDetails",
                    "{controller}/{id}",
                    new { controller = "Home", action = "Details" },
                    new { id = @"\d+" }
                );
    
                routes.MapRoute(
                    "Default", // Route name
                    "{controller}/{action}/{id}", // URL with parameters
                    new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
                );
