    static object GetWebRequestScopedDataContextInternal(Type type, string key, string connectionString)                                   
    {
        object context;
 
        if (HttpContext.Current == null)
        {
            if (connectionString == null)
                context = Activator.CreateInstance(type);
            else
                context = Activator.CreateInstance(type, connectionString);
 
            return context;
        }
 
        // *** Create a unique Key for the Web Request/Context 
        if (key == null)
            key = "__WRSCDC_" + HttpContext.Current.GetHashCode().ToString("x") + Thread.CurrentContext.ContextID.ToString();
 
        context = HttpContext.Current.Items[key];
        if (context == null)
        {
            if (connectionString == null)
                context = Activator.CreateInstance(type);
            else
                context = Activator.CreateInstance(type, connectionString);
 
            if (context != null)
                HttpContext.Current.Items[key] = context;
        }
 
        return context;
    }
