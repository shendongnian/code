    public T GetSection<T>(string sectionName) where T : class
    {
        Configuration config = WebConfigurationManager.OpenWebConfiguration(HostingEnvironment.ApplicationVirtualPath + "/ExternalConfig");
        return config.GetSection(sectionName) as T;
    }
