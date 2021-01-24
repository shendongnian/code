    public class A
    {
    	public string Foo { get; set; }
    }
    
    public class Program
    {
        // This is a local variable. If you set something else to this one, the original won't be changed
        //                              |
        //                              V
    	public static void DoSomething(A a)
    	{
    		a.Foo = "42"; // <---- This changes the property in the original
    		a = new A     // <---- This sets something to the local variable a
    		{
    			Foo = "Hello world"
    		};
    	}
    	
        // This variable is passed by references. If you set something else to this one, the original will be changed
        //                                  |    |
        //                                  V    V
    	public static void DoSomethingElse(ref A a)
    	{
    		a.Foo = "42"; // <---- This changes the property in the original
    		a = new A     // <---- This sets something to the original
    		{
    			Foo = "Hello world"
    		};
    	}
    	
    	public static void Main()
    	{
    		var a = new A
    		{
    			Foo = "Bar"
    		};
    		DoSomething(a);
    		
    		Console.WriteLine(a.Foo); // This outputs 42
    		
            // notice this --v
    		DoSomethingElse(ref a);
    		
    		Console.WriteLine(a.Foo); // This outputs Hello world
    	}
    }
