    static QueryManager()
    {
    
      Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
      ConnectionStringsSection section = config.GetSection("connectionStrings") as 
                                         ConnectionStringsSection;
    
      if (section.SectionInformation.IsProtected)
      {
        section.SectionInformation.UnprotectSection();
      }            
                
      unikSignConnectionString = section.ConnectionStrings["USConnect"].ConnectionString;
    
      if (unikSignConnectionString == null)
      {
        throw new ConfigurationErrorsException("Database server not configured");
      }
    }
