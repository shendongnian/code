            App_Start.AutoMapperConfig.Initialize();
            //AreaRegistration.RegisterAllAreas();
            var adminArea = new rentcar2.Areas.Admin.AdminAreaRegistration();
            var adminAreaContext = new AreaRegistrationContext(adminArea.AreaName, RouteTable.Routes);
            adminArea.RegisterArea(adminAreaContext);
            var defaultArea = new rentcar2.Areas.Public.PublicAreaRegistration();
            var defaultAreaContext = new AreaRegistrationContext(defaultArea.AreaName, RouteTable.Routes);
            defaultArea.RegisterArea(defaultAreaContext);
