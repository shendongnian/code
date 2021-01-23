    private static void AddAssembly(string fullName)
    {
        var config = WebConfigurationManager.OpenWebConfiguration("~");
        var compilationSection = (CompilationSection)config.GetSection("system.web/compilation");
    
        var myAssembly = new AssemblyInfo(fullName);
        compilationSection.Assemblies.Add(myAssembly);
        config.Save();
    }
