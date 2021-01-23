    Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        string missingAssemblyName = args.Name.Remove(args.Name.IndexOf(',');
        if ( missingAssemblyName == "PresentationCore.resources" )
        {
             string s = "C:\Program Files\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\PresentationCore.resources.dll";
             return Assembly.LoadFile(s);
        }
        return;
    }
