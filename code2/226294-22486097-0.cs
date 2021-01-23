    extern alias Assembly1Reference;
    extern alias Assembly2Reference;
    
    static void Load()
    {
        AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        Do();
    }
        
    static void Do()
    {
        new Assembly1Reference.Assembly.Class();
        new Assembly2Reference.Assembly.Class();
    }
    
    static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        string currentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        if(args.Name == "Name of assembly1")//Found in csproj file after referenced and built
        {
            return System.Reflection.Assembly.LoadFile(System.IO.Path.Combine(currentPath, "Assembly1.dll"));
        }
        if(args.Name == "Name of assembly2")//Found in csproj file after referenced and built
        {
            return System.Reflection.Assembly.LoadFile(System.IO.Path.Combine(currentPath, "Assembly2.dll"));
        }
        return null;
    }
