    public static T ReturnType<T>(string stringValue)
    {
    	if (typeof(T) == typeof(int))
    		return (T)(object)1;
    	else if (typeof(T) == typeof(FooBar))
    		return (T)(object)new FooBar(stringValue);
    	else
    		return default(T);
    }
    
    public class FooBar
    {
    	public FooBar(string something)
    	{}
    }
