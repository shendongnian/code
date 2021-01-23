    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        ModelBinders.Binders.Add( typeof( int ), new AlbumModelBinder() );
        RegisterRoutes( RouteTable.Routes );
    }
