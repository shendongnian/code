    using System;
    
    class Program
    {
        static void Main()
        {
    	// Input array.
    	int[] array = { 1, 2, 3 };
    
    	// Print.
    	foreach (int value in array)
    	{
    	    Console.WriteLine(value);
    	}
    	Console.WriteLine();
    
    	// Reverse.
    	Array.Reverse(array);
    
    	// Print.
    	foreach (int value in array)
    	{
    	    Console.WriteLine(value);
    	}
    	Console.WriteLine();
    
    	// Reverse again.
    	Array.Reverse(array);
    
    	// Print.
    	foreach (int value in array)
    	{
    	    Console.WriteLine(value);
    	}
        }
    }
