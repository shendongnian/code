    using System;
    using System.Collections.Generic;
    
    public class Test
    {
    	public static void Main()
    	{
    		var input = new[] { 1, 2, 2, 3, 4, 4, 3, 2, 2, 1 };
    		
    		var output = GetUniqueAdjacent(input);
    		
    		foreach (var o in output)
    		{
    			Console.WriteLine(o);
    		}
    	}
    	
    	public static IEnumerable<int> GetUniqueAdjacent(IEnumerable<int> input)
    	{
    		bool first = true;
    		int previous = -1;
    		foreach (var i in input)
    		{
    			if (first)
    			{
    				previous = i;
    				yield return i;
    				first = false;
    				continue;
    			}
    			
    			if (i == previous)
    			{
    				previous = i;
    				continue;
    			}
    			
    			previous = i;
    			yield return i;
    		}
    	}
    }
