    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string[] values = new string[]{"banana", "papaya", "melon"};
    
    		var result = values.Aggregate((x,y) => x + ", " + y);
    		
    		Console.WriteLine(result);
    	}
    }
