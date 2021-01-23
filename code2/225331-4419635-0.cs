       routes.MapRoute(
            //// Route name
            "Route1",
            //// URL with parameters
            "Custom/{param2}/{param3}",
            //// Parameter defaults
            new { controller = "MyController", action = "MyActionName", param2 = string.Empty, param3 = string.Empty });
       routes.MapRoute(
            //// Route name
            "Route2",
            //// URL with parameters
            "Custom/{param1}/{param2}/{param3}",
            //// Parameter defaults
            new { controller = "MyController", action = "MyActionName", param2 = string.Empty, param3 = string.Empty, param1 = string.Empty });
