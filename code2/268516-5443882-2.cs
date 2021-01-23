    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        RegisterGlobalFilters(GlobalFilters.Filters);
        RegisterRoutes(RouteTable.Routes);
        ModelMetadataProviders.Current = new MyMetadataProvider();
    }
