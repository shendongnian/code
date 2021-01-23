    AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
    static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        foreach (Assembly anAssembly in AppDomain.CurrentDomain.GetAssemblies())
            if (anAssembly.FullName == args.Name)
                return anAssembly;
        return null;
    }
