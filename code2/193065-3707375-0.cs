    ...
    protected void Application_Start() {
        ISessionFactory sf =
            DataRepository
                .CreateSessionFactory(
                    ConfigurationManager
                        .ConnectionStrings["conn_string"]
                        .ConnectionString
                );
    
    //use windsor castle to inject the session 
    ControllerBuilder
        .Current
        .SetControllerFactory(new WindsorControllerFactory(sf));
    }
    ...
