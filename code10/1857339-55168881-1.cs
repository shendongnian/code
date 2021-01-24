    using System;
    using System.Collections.Generic;
    public class Program
    {
    	public static void Main()
    	{
    		var animals = new List<List<string>>()
    		{
    			new List<string> { "Elephant", "26", "Thailand" },
    			new List<string> { "Elephant", "40", "Thailand" },
    			new List<string> { "Ant", "2", "Australia" },
    			new List<string> { "Camel", "1", "Nigeria" }
    		};
    		int index= animals.FindIndex(r => r.Contains("Camel"));
    		Console.WriteLine(index);
    	}
    }
