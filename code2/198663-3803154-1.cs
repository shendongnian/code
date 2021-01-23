    int MD_AUTH_ANONYMOUS = 1;
    int MD_AUTH_BASIC = 2;
    int MD_AUTH_NT = 4;
    using(DirectoryEntry w3svc = new DirectoryEntry(@"IIS://Localhost/W3SVC"))
    {
      using(DirectoryEntry webSite = w3svc.Children.Add(iisNumber, "IIsWebServer"))
      {
        // Configure website settings here...
        ....
        webSite.CommitChanges();
        using(DirectoryEntry siteRoot = webSite.Children.Add("root",
                                            IISSchemaClasses.IIsWebVirtualDir))
        {
          // Configure root application settings...
          ....
          // Only allow Basic and NTLM authentication
          siteRoot.Properties["AuthFlags"].Value = MD_AUTH_BASIC | MD_AUTH_NT 
          siteRoot.CommitChanges();
        }
        
      }
    }
