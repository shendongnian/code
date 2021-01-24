    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var guid = Guid.ParseExact(
                "\"ab9ffd2c3-6e456daaaaaaaaaaaaaaaaa\"" // guid with masked " inside
                .Replace("-","")                        // remove all - for N
                .Replace("\"",""), "N");                // remove all \" as well
    		
    		Console.WriteLine( guid );
    	}
    }
