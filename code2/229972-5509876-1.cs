    public static class Repository
    {
    	static SimpleRepository repo;
    		
    	public static IRepository GetRepository()
    	{
    		if (repo == null)
    		{
    			lock (repo)
    			{
    				repo = new SimpleRepository("NamedConnectionString",
    					SimpleRepositoryOptions.RunMigrations);
    			}
    		}
    
    		return repo;
    	}
    }
