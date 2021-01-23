        routes.MapRoute(
            "Default", // Route name
            "{controller}/{action}/{id}/{page}", // URL with parameters
            new
            {
                controller = "Home",
                action = "Index",
                id = UrlParameter.Optional,
                page = UrlParameter.Optional
            } // Parameter defaults
        );
