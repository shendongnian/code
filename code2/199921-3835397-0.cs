    using(ServerManager serverManager = new ServerManager())
    {  
        ApplicationPool pool = serverManager.ApplicationPools["YourAppPool"];
  
        pool.ProcessModel.IdentityType = ProcessModelIdentityType.SpecificUser;  
        pool.ProcessModel.UserName = @"TheUser";  
        pool.ProcessModel.Password = @"ThePassword";  
                
        serverManager.CommitChanges();  
    }
