    AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
    private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName(args.Name), AssemblyBuilderAccess.Run);
        _dumbAssemblies.Add(args.Name, ab);
        return ab;
    }
    private Dictionary<string, AssemblyBuilder> _dumbAssemblies;
