    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		foreach(var i in GetCol()) {
    			Console.WriteLine(i);
    		}
    	}
    	
    	private static List<int> GetCol() {
    		Console.WriteLine("I have been called");
    		
    		return new List<int>(){1, 2, 3, 4};
    	}
    }
    /* Output
    I have been called
    1
    2
    3
    4 */
