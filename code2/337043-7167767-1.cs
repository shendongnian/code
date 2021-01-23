    protected void Application_Start()
    {
        ModelBinders.Binders.Add(typeof(decimal), new TreasuryIndexRateDecimalBinder());
        AreaRegistration.RegisterAllAreas();
        RegisterRoutes(RouteTable.Routes);
    }
    
