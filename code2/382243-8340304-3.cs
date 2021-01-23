    namespace NestedTest
    {
    	public class A
    	{
    		public static void MyAMethod()
    		{
    			System.Console.WriteLine("public static void MyAMethod()");
    		}
    
    		public class B
    		{
    			public void MyBMethod()
    			{
    				MyAMethod();
    			}
    		}
    	}
    }
