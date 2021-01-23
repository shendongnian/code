    var className = "StackOverflowLib.Class1";
    var assemblyName = "StackOverflowLib.dll";
    var currentAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    var obj = Activator.CreateInstance(Path.Combine(currentAssemblyPath, assemblyName), className);
    static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        var currentAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (File.Exists(Path.Combine(currentAssemblyPath, args.Name)))
        {
            return Assembly.LoadFile(Path.Combine(currentAssemblyPath, args.Name));
        }
        return null;
    }
    
