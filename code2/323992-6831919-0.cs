    AppDomain.CurrentDomain.AssemblyResolve += OnCurrentDomainAssemblyResolve
    private static Assembly OnCurrentDomainAssemblyResolve(object sender, ResolveEventArgs args)
    {
        if (args.Name == "myDynamicAssemblyName") return _myPreviouslyLoadedDynamicAssemblyObtainedFromAssemblyLoadFrom;
        return null;
    }
