    AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolveHandler;
    ..
    static Assembly AssemblyResolveHandler(object sender, ResolveEventArgs args)
    {
      string assemblyPath = "yourpath";
      return Assembly.LoadFrom(assemblyPath + args.Name);
    }
