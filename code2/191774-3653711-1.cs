    using System;
    class Program
    {
    	static T GenericFunction<T>(T t)
    	{
    		Console.WriteLine("GenericFunction<T>(T)");
    		return default(T);
    	}
	
    	static T[] GenericFunction<T>(T[] t)
    	{
    		// Call the non-array function
    		for(int i = 0; i < t.Length; ++i)
    			t[i] = GenericFunction(t[i]);
    		Console.WriteLine("GenericFunction<T>(T[])");
    		return new T[4];
    	}
	
    	static void Main()
    	{
    		int[] arr = {1,2,3};
    		int i = 42;
		
    		GenericFunction(i);   // Calls non-array version
    		GenericFunction(arr); // Calls array version
    	}
    }
