    public class Persist<T>
    {
    	private string ObjectName;
    
    	public Persist( string Name )
    	{
    		ObjectName = Name;
    	}
    
    	public T Get()
    	{
    		return (T)(HttpContext.Current.Session[ObjectName]); 
    	}
    
    	public void Set(T value)
    	{
    		HttpContext.Current.Session[ObjectName] = value;
    	}
    }
