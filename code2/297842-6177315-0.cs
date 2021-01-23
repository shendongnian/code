    class MyObject{}
    class Derived : MyObject {}
    internal class Program
    {
    
    	public static void Main()
    	{
    		Func<Derived> constructor = GetObjectConstructor<Derived>();
    		var obj = constructor();
    	}
    	private static Func<T> GetObjectConstructor<T>() where T : MyObject, new()
    	{
    		return () => new T();
    	}
    }
