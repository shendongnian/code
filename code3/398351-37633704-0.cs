        using System;
    
    class Program
    {
        static void Main()
        {
    	//
    	// Get the current month integer.
    	//
    	DateTime now = DateTime.Now;
    	//
    	// Write the month integer and then the three-letter month.
    	//
    	Console.WriteLine(now.Month);
    	Console.WriteLine(now.ToString("MMM"));
        }
    }
