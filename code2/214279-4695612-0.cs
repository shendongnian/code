    Microsoft.Web.Administration.Configuration config = serverManager.GetApplicationHostConfiguration();
    ConfigurationSection sitesSection = config.GetSection("system.applicationHost/sites");
    ConfigurationElementCollection sitesCollection = sitesSection.GetCollection();
    ConfigurationElement siteElement = sitesCollection.CreateElement("site");
         
