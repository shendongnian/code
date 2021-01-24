    public interface IDataProvider
    {
    	object GetData();
    }
    
    public class Database : IDataProvider
    {
    	public object GetData()
    	{
    		// interact with database to get data
    
    		throw new NotImplementedException();
    	}
    }
    
    public class MockDatabase : IDataProvider
    {
    	public object GetData()
    	{
    		return new List<string>
    		{
    			"some_mock_data"
    		};
    	}
    }
