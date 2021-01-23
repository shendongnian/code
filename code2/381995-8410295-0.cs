            routes.MapRoute(
                "TypeRoute", // Route name
                "Public/{wantedtype}", // URL with parameters
                new { controller = "Public", action = "get_json", wantedtype = UrlParameter.Optional } // Parameter defaults
            );
