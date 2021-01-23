    public DoSomething()
    {
        //Add the handler
        AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve
    
        //Load your assembly...
    }
    
    private System.Reflection.Assembly CurrentDomain_AssemblyResolve(Object sender, ResolveEventArgs e)
    {
        foreach (System.Reflection.Assembly a In AppDomain.CurrentDomain.GetAssemblies())
        {
           if (a.FullName == <<The one you need>>) return a
        }
    }
