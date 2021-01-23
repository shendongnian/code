    public class ThreadedMethod<T>
    {
    
    	private T result;
    	public T Result 
    	{
    		get { return result; }
    		private set { result = value; }
    	}
    
    	public ThreadedMethod()
    	{
    	}
    
    	//If supporting .net 3.5
    	public void ExecuteMethod(Func<T> func)
    	{
    		Result = func.Invoke();
    	}
    
    	//If supporting only 2.0 use this and 
    	//comment out the other overload
    	public void ExecuteMethod(Delegate d)
    	{
    		Result = (T)d.DynamicInvoke();
    	}
    }
