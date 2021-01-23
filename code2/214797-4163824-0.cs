	class AnotherClass {}
	
	class Test
	{
		static Test()
    	{
    		Console.WriteLine("Hello, world!");
    	}
    	
		public static AnotherClass ClassInstance { get { return new AnotherClass(); } }
	}
	class Program
	{
	    public static void Main()
	    {
	    	var x = Test.ClassInstance;
	    }
	}
