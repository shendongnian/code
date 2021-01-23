    using (var manager = new ServerManager())
    {
        // Get the first web site
        var site = manager.Sites.Cast<Site>().Where(s => s.Id == 1).FirstOrDefault();
        if (site == null)
        {
            throw new Exception("The site with ID = 1 doesn't exist");
        }
        // get the application you want to set the framework version to
        var application = site.Applications["/vDirName"];
        if (application == null)
        {
            throw new Exception("The virtual directory /vDirName doesn't exist");
        }
        // get the corresponding application pool
        var applicationPool = manager.ApplicationPools
            .Cast<Microsoft.Web.Administration.ApplicationPool>()
            .Where(appPool => appPool.Name == application.ApplicationPoolName)
            .FirstOrDefault();
        if (applicationPool == null)
        {
            throw new Exception("The virtual directory /vDirName doesn't have an application pool associated");
        }
        applicationPool.ManagedRuntimeVersion = "v4.0.30319";
        manager.CommitChanges();
    }
