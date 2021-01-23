    public static class ContextFactory
    {
    private static bool disposeRegistered = false;
    public static MyEntityContext GetContext()
    {
        RegisterDispose();
        var instance = (MyEntityContext)HttpContext.Current
            .Items["MyEntityContext"];
        if (instance == null)
        {
            instance = new MyEntityContext();
            HttpContext.Current.Items["MyEntityContext"] = instance;
        }
       
        return instance;    
    }
    private static void RegisterDispose()
    {
        if (disposeRegistered)
            return;
        
        HttpContext.Current.ApplicationInstance
           .EndRequest += (s,e) =>
        {
            var instance = HttpContext.Current
                .Items["MyEntityContext"] as IDisposable;
        
            if (instance != null)
            {
                instance.Dispose();
            }
        };
        this.disposeRegistered = true;
    }
    }
