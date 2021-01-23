    public class MyClass
    {
    	public void PrintHello()
    	{
    		Console.WriteLine("Hello World");
    	}
    }
    //...
    
    public void InvokeMethod(object obj, string method)
    {
      // call the method
      obj.GetType().GetMethod(method).Invoke(obj, null);
    }
    
    //...
    var o = new MyClass();
    var method = "PrintHello";
    //...
    InvokeMethod(o, method);
    
