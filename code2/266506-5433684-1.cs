    using Microsoft.Web.Administration;    
    ...
    
    using (ServerManager serverManager = new ServerManager())
    {
      ApplicationPool appPool = 
          serverManager.ApplicationPools.Where(a => a.Name.Equals(appPoolName))
          .Single();
      appPool.ManagedRuntimeVersion = "v2.0";
      serverManager.CommitChanges();
    }
