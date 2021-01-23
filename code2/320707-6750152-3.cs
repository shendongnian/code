    private bool AssemblyExist(string fullName)
    {
        var webConfig = new ExeConfigurationFileMap { ExeConfigFilename = GlobalSettings.FullpathToRoot + "web.config" };
        var config = ConfigurationManager.OpenMappedExeConfiguration(webConfig, ConfigurationUserLevel.None);
        var compilationSection = (CompilationSection)config.GetSection("system.web/compilation");
    
        return compilationSection.Assemblies.Cast<AssemblyInfo>().Any(assembly => assembly.Assembly == fullName);
    }
