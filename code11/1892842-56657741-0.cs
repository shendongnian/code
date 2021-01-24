    static void Main(string[] args)
    {
        foreach (var an in Assembly.GetEntryAssembly().GetReferencedAssemblies())
        {
            WriteLine(an.Name);
        }
    
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            WriteLine(assembly.FullName);
        }
        LoadType();
    }
    static void LoadType()
    {
        typeof(MyPackage.Cars);
    }
