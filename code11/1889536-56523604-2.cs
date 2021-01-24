    public class MainClass : IMainClass
    {       
    	private readonly ILogger _logger;
    	private readonly IDatabase _db;
    
    	public MainClass(ILogger logger, IDatabase db)
    	{
    		_logger = logger;  
    		_db = db;
    	}
    	public void AddDetails(Data data)
    	{
    		//do some business operations 
    		_db.Add(data);
    		_logger.Information("added");
    	}
    }
