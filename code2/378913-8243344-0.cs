    private Singleton()
    {
        // do whatever
    }
    
    public Singleton GetMySingleton()
    {
        if(HttpContext.Current.Session["MyCustomSingleton"] == null)
            HttpContext.Current.Session["MyCustomSingleton"] = new Singleton();
        //
    
        return (Singleton)HttpContext.Current.Session["MyCustomSingleton"];
    }
