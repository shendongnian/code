    public class BaseClass
    	{
    		public string HelloMessage = "Hello, World!";
    	}
    
    	public class SubClass : BaseClass
    	{
    		public string ArbitraryMessage = "Uh, Hi!";
    	}
    
    	public class Test
    	{
    		static void Main()
    		{
    			SubClass subClass = new SubClass();
    
    			// Inheritence
    			Console.WriteLine(subClass.HelloMessage);
    		}
    	}
