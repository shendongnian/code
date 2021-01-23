    using (ServerManager serverManager = new ServerManager())
    {
        Site site = serverManager.Sites["Default Web Site"];
        Application application =  site.Applications["/MyApplication"];
        site.Applications.Remove(application);
        serverManager.CommitChanges();
    }
