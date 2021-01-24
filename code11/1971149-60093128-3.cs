    OfficeDevPnP.Core.AuthenticationManager authMgr = new OfficeDevPnP.Core.AuthenticationManager();
      
                 string siteUrl = "https://******.sharepoint.com/sites/CommunitySite";
                 string userName = "userh@******.onmicrosoft.com";
                 string password = "******";
      
                 using (var ctx = authMgr.GetSharePointOnlineAuthenticatedContextTenant(siteUrl, userName, password))
                 {
                     Web web = ctx.Web;
                     ctx.Load(web);
                     ctx.ExecuteQueryRetry();
      
                     List sitePagesList = web.Lists.GetByTitle("Site Pages");
      
                     ctx.Load(sitePagesList);
                     ctx.Load(sitePagesList.RootFolder);
                     ctx.ExecuteQueryRetry();
      
                     var pageTitle = "home.aspx";
                     sitePagesList.RootFolder.Files.AddTemplateFile(sitePagesList.RootFolder.ServerRelativeUrl + "/" + pageTitle, TemplateFileType.StandardPage);
                      
                     ctx.ExecuteQueryRetry();
                 }
             }
