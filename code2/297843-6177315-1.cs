    class MyObject{}
    class Derived : MyObject {}
    internal class Program
    {
    
    	public static void Main()
    	{
    		// the type you want to construct
    		Type type = typeof (Derived);
    		
    		MethodInfo getConstructor = MakeConstructorGetter(type);
    		Func<MyObject> constructor = (Func<MyObject>)getConstructor.Invoke(null, null);
    
    		var obj = constructor();
    		Console.WriteLine(obj.GetType());
    	}
    
    	private static MethodInfo MakeConstructorGetter(Type type)
    	{
    		MethodInfo mi = typeof(Program).GetMethod("GetObjectConstructor", BindingFlags.Static | BindingFlags.NonPublic);
    		var getConstructor = mi.MakeGenericMethod(type);
    		return getConstructor;
    	}
    
    	private static Func<T> GetObjectConstructor<T>() where T : MyObject, new()
    	{
    		return () => new T();
    	}
    }
