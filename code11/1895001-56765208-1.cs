    using System;
    using System.Linq;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var input = "some random string with abc and 123";
    		var words = new List<String>() {"123", "abc"};
    		
    		var foundAll = words.Any(word => input.Contains(word));
    		
    		Console.WriteLine("Contains: {0}", foundAll);
    	}
    }
