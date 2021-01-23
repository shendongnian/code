     SPSecurity.RunWithElevatedPrivileges(delegate() 
     {
     foreach (SPWebApplication webApp in SPWebService.ContentService.WebApplications)
                {                    
                    foreach (SPSite siteCollection in webApp.Sites)
                    {
                        foreach(SPWeb web in siteCollection.RootWeb.GetSubwebsForCurrentUser())
                        {
                           dropDownSite.Items.Add(web.Url);
                        }
    
    
                    }
                }
      });
