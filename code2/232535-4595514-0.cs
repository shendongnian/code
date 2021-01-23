      var filemap = new System.Configuration.ExeConfigurationFileMap();
                
                System.Configuration.Configuration config =  System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(filemap, System.Configuration.ConfigurationUserLevel.None);
    
    //usage: config.AppSettings["xxx"]
