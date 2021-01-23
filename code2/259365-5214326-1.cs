    private void ProtectSection(string sectionName,
                                       string provider)
    {
        Configuration config =
            WebConfigurationManager.
                OpenWebConfiguration(Request.ApplicationPath);
    
        ConfigurationSection section =
                     config.GetSection(sectionName);
    
        if (section != null &&
                  !section.SectionInformation.IsProtected)
        {
            section.SectionInformation.ProtectSection(provider);
            config.Save();
        }
    }
    
    private void UnProtectSection(string sectionName)
    {
        Configuration config =
            WebConfigurationManager.
                OpenWebConfiguration(Request.ApplicationPath);
    
        ConfigurationSection section =
                  config.GetSection(sectionName);
    
        if (section != null &&
              section.SectionInformation.IsProtected)
        {
            section.SectionInformation.UnprotectSection();
            config.Save();
        }
    }
