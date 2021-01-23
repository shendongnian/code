    class SomeClass<T>
    {
    	public static void someMethod(T param1)
    	{
    		Console.WriteLine(param1);
    	}
    }
...
    SomeClass<int>.someMethod(4);
