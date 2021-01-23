    private Singleton()
    {
        // do whatever
    }
    
    public Singleton GetMySingleton()
    {
        if(HttpContext.Current.Items["MyCustomSingleton"] == null)
            HttpContext.Current.Items["MyCustomSingleton"] = new Singleton();
        //
    
        return (Singleton)HttpContext.Current.Items["MyCustomSingleton"];
    }
