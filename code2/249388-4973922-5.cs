    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        RegisterRoutes(RouteTable.Routes);
        ModelMetadataProviders.Current = new DisplayMetaDataProvider();
    }
