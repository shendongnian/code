    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        RegisterRoutes(RouteTable.Routes);
        ModelBinders.Binders.Add(typeof(TimeSpan), new TimeSpanModelBinder());
    }
