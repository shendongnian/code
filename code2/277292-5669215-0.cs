    class BaseClass
    { public virtual void SomeMethod() {} }
    
    class Derived :BaseClass {}
    
    class MainClass
    {
    	public static void Main (string[] args)
    	{
    		Expression<Action<Derived>> expr = (instance) => instance.SomeMethod();
    		var method = (expr.Body as MethodCallExpression).Method;
    		Console.WriteLine(method.DeclaringType);
    	}
    }
