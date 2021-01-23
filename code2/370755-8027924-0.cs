    public void Test()
    {
    	using (IStatelessSession statelessSession = _sessionManager.OpenStatelessSession())
    	{
    		using (ITransaction transaction = statelessSession.BeginTransaction())
    		{
    			statelessSession.Insert(<ParentEntity>);
    			foreach(var childEntity in ParentEntity)
    			{
    				statelessSession.Insert(<childEntity>);
    			}
    			transaction.Commit();
    		}		
    	}
    }
