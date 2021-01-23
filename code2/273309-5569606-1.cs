    void Main()
    {
    	var simpleDelegate = "test".CreateDelegate<Func<string>>(new Test());
    	simpleDelegate().Dump();
    }
    
    class Test
    {
    	public string test() { return "hi"; }
    }
    	
    public static class ExtensionMethods
    {
    	public static T CreateDelegate<T>(this string methodName,object instance) where T : class
    	{
    		return Delegate.CreateDelegate(typeof(T), instance, methodName) as T;
    	} 
    }
