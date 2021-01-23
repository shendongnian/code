    // application initialization
    AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
    
    private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        if (args.Name.StartsWith("Widget.Net, Version="))
        {
            Assembly result = Assembly.LoadFrom("Widget.Net.dll");
            return result;
        }
        return null;
    }
