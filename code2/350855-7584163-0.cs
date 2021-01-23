    AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
    {
         string typeToLoad = args.Name;
         string myPath = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
         return Assembly.LoadFile(...);
    };
