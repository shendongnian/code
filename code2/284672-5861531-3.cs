    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
    
        RegisterGlobalFilters(GlobalFilters.Filters);
        RegisterRoutes(RouteTable.Routes);
    
        // Register your custom binder here:
        ModelBinders.Binders.Add(new KeyValuePair<Type, IModelBinder>(typeof(Student), new StudentBinder()));
    }
