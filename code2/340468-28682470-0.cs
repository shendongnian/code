    using Microsoft.Web.Administration;
    namespace KDC.UserWeb.RoleEntryPoint
    {
        {
            public override bool OnStart()
            {
        	    Enable32BitAppPool();
                return base.OnStart();
            }
            {
                base.Run();
            }
        
        public static void Enable32BitAppPool();
        {
        	ServerManager serverManager = new ServerManager();
    		ApplicationPoolCollection applicationPoolCollection = serverManager.ApplicationPools;
		    foreach (ApplicationPool applicationPool in applicationPoolCollection)
		    {
        		if( !String.IsNullOrEmpty(applicationPool.Name) && applicationPool.Name[0]  != '.' )
        		{
	            	serverManager.ApplicationPools[applicationPool.Name].Enable32BitAppOnWin64 = true;
    	        	serverManager.CommitChanges();
        		}
			}
        }
        
    }
