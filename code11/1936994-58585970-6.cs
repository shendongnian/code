    public static void Application_Start() {
        var whatIsMyType =  GetType();
        //You will see that our actual type is of ASP.global_asax,
        //which inherits  MvcApplication, which inherits  HttpApplication      
        //Other Stuff...
    }
