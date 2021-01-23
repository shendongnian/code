    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      RegisterGlobalFilters(GlobalFilters.Filters);
      RegisterRoutes(RouteTable.Routes);
      ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
    }
