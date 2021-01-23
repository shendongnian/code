    public interface IConnections
    {
    	void connect();
    	void disconnect();
    }
    
    public class A : IConnections
    {
    	public void connect()
    	{
    		//do something
    	}
    
    	public void disconnect()
    	{
    		//do something
    	}
    }
    
    public class B : IConnections
    {
    	public void connect()
    	{
    		//do something
    	}
    
    	public void disconnect()
    	{
    		//do something
    	}
    }
    
    public void make_connection(IConnections x)
    {
    	x.connect();
    	// Do some more stuff... 
    	x.disconnect();
    	return;
    }
