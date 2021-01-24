var names = new List<string>();
    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    			var names = new List<string>();
    			while(true)
     			{
    
                	Console.Write("type a name (or hit ENTER to quit)");
                	var input = Console.ReadLine();
                	if (string.IsNullOrWhiteSpace(input))
                	break;
              	names.Add(input);
      	}
    
      	if (names.Count >2)
           Console.WriteLine("{0} {1} and {2} others like your posts", names[0], names[1], names.Count - 2);}
    }
