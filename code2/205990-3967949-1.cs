    using (var manager = new ServerManager())
    {
        // Get the application pool given its name
        var appPool = manager.ApplicationPools["AppPoolName"];
        if (appPool == null)
        {
            throw new Exception("The application pool AppPoolName doesn't exist");
        }
        // set the managed pipeline mode
        appPool.ManagedPipelineMode = pool.ManagedPipelineMode;
        // save
        manager.CommitChanges();
    }
