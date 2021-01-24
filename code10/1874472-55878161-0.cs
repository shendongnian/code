    using System;
					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine(CreateString(1));
    		Console.WriteLine(CreateString(284));
    	}
    	
    	
    	public static string CreateString(int id)
    	{
    		var n = DateTime.Now;
    		return "G" + n.Year.ToString().Substring(2,2) + n.Month.ToString().PadLeft(2,'0') + id.ToString().PadLeft(5,'0');
    	}
    	
    }
    // This returns
    // G190400001
    // G190400284
