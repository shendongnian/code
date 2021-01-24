        public User GetDirectManagerForUser(GraphServiceClient _graphServiceClient, string managerId)
        {
    		//.Result, because this function in synchronious
    		try 
    		{		
    			var manager = await _graphServiceClient.Users[managerId].Manager.Request().GetAsync().Result;
    			return manager;
    		}
    		catch(Exception)
    		{
    			return null;
    		}
        } 
