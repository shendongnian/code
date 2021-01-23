    using MvcContrib.PortableAreas; // REMOVED THIS!
    
    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        RegisterGlobalFilters(GlobalFilters.Filters);
    
        PortableAreaRegistration.RegisterEmbeddedViewEngine(); // REMOVED THIS!
        RegisterRoutes(RouteTable.Routes);
    }
