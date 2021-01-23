    public HomeController(IDataRepository db)
    	: this(() => db, false)
    {
    	if (db == null)
    	{
    		throw new ArgumentNullException("db");
    	}
    }
    
    public HomeController()
    	: this(() => new SqlDataRepository(), true)
    {
    }
    
    private HomeController(Func<IDataRepository> repositoryRetriever, bool disposeOnFailure)
    {
    	IDataRepository repository = repositoryRetriever.Invoke();
    	try
    	{
    		this.repo = repository;
    	}
    	catch
    	{
    		if (disposeOnFailure)
    		{
    			repository.Dispose();
    		}
    
    		throw;
    	}
    }
