    private bool AssemblyExist(string fullName)
    {
        var config = WebConfigurationManager.OpenWebConfiguration("~");
        var compilationSection = (CompilationSection)config.GetSection("system.web/compilation");
    
        return compilationSection.Assemblies.Cast<AssemblyInfo>().Any(assembly => assembly.Assembly == fullName);
    }
