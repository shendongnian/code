    public abstract class HPCRequestBase<T> where T : HPCRequestBase<T>
    {
    	public delegate void RequestCompleteHandler(T request);
    	public event RequestCompleteHandler RequestComplete;
    
    	protected void OnRequestComplete(T request)
    	{
    		if (RequestComplete != null) {
    			RequestComplete(request);
    		}
    	}
    
    	public void Test( )
    	{
    		OnRequestComplete((T)this);
    	}
    
    }
    
    public class HPCRequest : HPCRequestBase<HPCRequest>
    {
    	public void Test2()
    	{
    		OnRequestComplete(this);
    	}
    }
    
    public class HPCRequestConfig : HPCRequestBase<HPCRequestConfig>
    {
        // Derived from the base class, not from HPCRequest 
    }
