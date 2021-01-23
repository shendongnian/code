    // this resolver works as long as the assembly is already loaded
    // with LoadFile/LoadFrom or Load(string) / Load(byte[])
    private static Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
    {
        var asm = (from a in AppDomain.CurrentDomain.GetAssemblies()
                  where a.GetName().FullName == args.Name
                  select a).FirstOrDefault();
        if(asm == null)
             throw FileNotFoundException(args.Name);     // this becomes inner exc
        return asm;
    }
    // place this somewhere in the beginning of your app:
    AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;
