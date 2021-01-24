    public class Test
    {
    	public static void Main()
    	{
    		dynamic bar = null;
    		
    		try
    		{
    			Foo(bar);
    		}
    		catch (Exception ex)
    		{
    			Console.WriteLine(ex);
    		}
    	}
    	
    	private static void Foo(string f) { }
    	private static void Foo(int? o) { }
    }
