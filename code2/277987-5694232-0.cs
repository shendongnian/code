    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        RegisterRoutes(RouteTable.Routes);
    
        DataAnnotationsModelValidatorProvider.RegisterAdapter(
            typeof(NameAttribute), typeof(RegularExpressionAttributeAdapter)
        );
    }
