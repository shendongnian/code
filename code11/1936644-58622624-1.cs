    protected void Application_Start()
    {
        //Some code.
 
        // Register global filter
        GlobalFilters.Filters.Add(new LogHttpRequestAttribute());
    }
