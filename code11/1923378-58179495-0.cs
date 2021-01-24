    public class Repository : IDisposable
    {
    	private EA.Repository _repo;
    
    	protected Repository(string connectionString)
    	{
    		_repo = new EA.Repository();
    		_repo.OpenFile(connectionString);
    	}
    
    	...
    
    	public void Dispose()
    	{
    		_repo.CloseFile();
    		_repo = null;
    	}
    }
