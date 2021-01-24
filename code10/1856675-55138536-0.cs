    public interface IMySleepContext
    {
    	void Sleep(int milliseconds);
    }
    
    public class MySleepContext : IMySleepContext
    {
    	public void Sleep(int milliseconds)
    	{
    		Thread.Sleep(milliseconds);
    	}
    }
    
    public class MyController
    {
    	private readonly IMySleepContext _mySleepContext;
    
    	public MyController(IMySleepContext mySleepContext)
    	{
    		_mySleepContext = mySleepContext;
    	}
    
    	public void MyMethod()
    	{
    		//do something
    		_mySleepContext.Sleep(20000);
    		//do somethign
    	}
    }
    
