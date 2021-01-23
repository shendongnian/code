     Configuration webConfig = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
    
            ConfigurationSection webConfigSections = webConfig.GetSection("system.web/handlers");
            if (webConfigSections != null)
            {
                PropertyInformation t = webConfigSections.ElementInformation.Properties["add"];
    
                if (t != null)
                          // now you can read its properties ....
                           // p.s. if you have more then 1 child you should use  PropertyInformation  collection.
            }
