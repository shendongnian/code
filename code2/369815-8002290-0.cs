    public class MyClass<TClass> where TClass : class
    {
    	public void FuncA<Ta>() where Ta : class
    	{
    	}
    
    	public void FuncB<Tb>() where Tb : TClass
    	{
    	}
    
    	public void Func()
    	{
    		FuncA<TClass>();
    		FuncB<TClass>();
    	}
    }
