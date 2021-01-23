    Configuration config = serverManager.GetApplicationHostConfiguration();
         
    // Change this line:    
    ConfigurationSection isapiFiltersSection = 
                               config.GetSection("system.webServer/isapiFilters");
    // To this by adding an extra param specifying the site name:
    ConfigurationSection isapiFiltersSection = 
                  config.GetSection("system.webServer/isapiFilters", "my site name");
    ConfigurationElementCollection isapiFiltersCollection = 
                               isapiFiltersSection.GetCollection();
    
    ConfigurationElement filterElement = isapiFiltersCollection.CreateElement("filter");
    filterElement["name"] = @"SalesQueryIsapi";
    filterElement["path"] = @"c:\Inetpub\www.contoso.com\filters\SalesQueryIsapi.dll";
    filterElement["enabled"] = true;
    filterElement["enableCache"] = true;
    isapiFiltersCollection.Add(filterElement);
    
    serverManager.CommitChanges();
