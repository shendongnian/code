    try
    {
        string siteUrl = "SiteUrl";
        AuthenticationManager authManager = new AuthenticationManager();
        using (ClientContext context = authManager.GetWebLoginClientContext(siteUrl))
        {
            List list = context.Web.Lists.GetByTitle("LibName");
            context.Load(list);
            context.ExecuteQuery();
            Folder folder = list.RootFolder.CreateFolder("NewFolder");
        }
    }
    catch (Exception ex)
    {
        // log error
        throw;
    }
