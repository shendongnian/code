    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
        filters.Add(new HandleErrorAttribute());
    }
    
    protected void Application_Start()
    {
        RegisterGlobalFilters(GlobalFilters.Filters);
    }
