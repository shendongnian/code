    protected void Application_Start()
    {
        ...
        ViewEngines.Engines.Add(new WebFormViewEngine());
        ViewEngines.Engines.Add(new RazorViewEngine());
        ...
    }
