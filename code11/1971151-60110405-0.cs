    string siteUrl = "https://*****.sharepoint.com/sites/team";
    string userName = "admin@****.onmicrosoft.com";
    string password = "***";
    
    OfficeDevPnP.Core.AuthenticationManager authMgr = new OfficeDevPnP.Core.AuthenticationManager();
    
    #region O365
    using (var ctx = authMgr.GetSharePointOnlineAuthenticatedContextTenant(siteUrl, userName, password))
    {
    	Web web = ctx.Web;
    	ctx.Load(web.Lists);
    	ctx.Load(web, w => w.SupportedUILanguageIds);
    	ctx.Load(web);
    
    	ctx.ExecuteQueryRetry();
    	//Create the Page
    	var homePage = ctx.Web.AddClientSidePage("HomePage.aspx", true);
    	homePage.AddSection(CanvasSectionTemplate.ThreeColumn, 5);	
    	homePage.Save();
    }
