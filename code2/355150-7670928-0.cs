      DirectoryEntry defaultWebSite = GetWebSiteEntry(DEFAULT_WEB_SITE_NAME);
      DirectoryEntry defaultWebSiteRoot = new DirectoryEntry(defaultWebSite.Path + "/Root");
      //Create and setup new virtual directory
      DirectoryEntry virtualDirectory = defaultWebSiteRoot.Children.Add(applicationName, "IIsWebVirtualDir");
      virtualDirectory.Properties["Path"][0] = physicalPath;
      virtualDirectory.Properties["AppFriendlyName"][0] = applicationName;
      virtualDirectory.CommitChanges();
      // IIS6 - it will create a virtual directory
      // IIS7 - it will create an application
      virtualDirectory.Invoke("AppCreate", 1);
      object[] param = { 0, applicationPoolName, true };
      virtualDirectory.Invoke("AppCreate3", param);
