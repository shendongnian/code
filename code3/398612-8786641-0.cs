    protected void Application_Start() {
        AreaRegistration.RegisterAllAreas();
     
        // Register global filter
        GlobalFilters.Filters.Add(new MyActionFilterAttribute());
        
        RegisterGlobalFilters(GlobalFilters.Filters);
        RegisterRoutes(RouteTable.Routes); 
    }
