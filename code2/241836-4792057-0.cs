    using Microsoft.Web.Administration;
    ...
    
    using(ServerManager serverManager = new ServerManager())
    {
      ApplicationPool newPool = serverManager.ApplicationPools.Add("MyNewPool");
      newPool.ManagedRuntimeVersion = "v4.0";
      serverManager.CommitChanges();
    }
