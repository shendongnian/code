    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var anyvar = "1 2 3";
    		int[] arrayvar = anyvar.Split(' ').Select(Int32.Parse).ToArray(); 
            Console.WriteLine(arrayvar[1]); // expects 2 
    	}
    }
