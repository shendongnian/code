        private void RegisterRoutes()
        {
            // Edit the base address of Service1 by replacing the "Service1" string below
            RouteTable.Routes.Add(new ServiceRoute("Service1", new WebServiceHostFactory(), typeof(Service1)));
    
            RouteTable.Routes.Add(new ServiceRoute("SoapService", new SoapServiceHostFactory(), typeof(Service1)));
        }
