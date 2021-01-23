    using System;
    using System.Text;
    class Program
        {
        static void Main()
        {
    	const string s = "This is an example.";
    
    	// A
    	// Create new StringBuilder from string
    	StringBuilder b = new StringBuilder(s);
    	Console.WriteLine(b);
    
    	// B
    	// Replace the first word
    	// The result doesn't need assignment
    	b.Replace("This", "Here");
    	Console.WriteLine(b);
    
    	// C
    	// Insert the string at the beginning
    	b.Insert(0, "Sentence: ");
    	Console.WriteLine(b);
        }
    }
