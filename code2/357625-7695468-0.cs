    using System;
    using System.IO;
    
    class Program
    {
        static void Main()
        {
    	// The name of the file
    	const string fileName = "test.txt";
    
    	// Create new FileInfo object and get the Length.
    	FileInfo f = new FileInfo(fileName);
    	long s1 = f.Length;
    
    	// Change something with the file. Just for demo.
    	File.AppendAllText(fileName, " More characters.");
    
    	// Create another FileInfo object and get the Length.
    	FileInfo f2 = new FileInfo(fileName);
    	long s2 = f2.Length;
    
    	// Print out the length of the file before and after.
    	Console.WriteLine("Before and after: " + s1.ToString() +
    	    " " + s2.ToString());
    
    	// Get the difference between the two sizes.
    	long change = s2 - s1;
    	Console.WriteLine("Size increase: " + change.ToString());
        }
    }
