    public static ComponentRegistration<T> AddServiceRoute<T>(
        this ComponentRegistration<T> registration, 
        string routePrefix, 
        ServiceHostFactoryBase serviceHostFactory, 
        string routeName) where T : class
    {
        var route = new ServiceRoute("Services/" + routePrefix + ".svc",
                                     serviceHostFactory,
                                     registration
                                         .Implementation
                                         .GetInterfaces()
                                         .Single());
        RouteTable.Routes.Add(routeName, route);           
        return registration;
    }   
