    using System;
    using System.Collections;
    
    class Program
    {
        static Hashtable GetHashtable()
        {
    	// Create and return new Hashtable.
    	Hashtable hashtable = new Hashtable();
    	hashtable.Add("Area", 1000);
    	hashtable.Add("Perimeter", 55);
    	hashtable.Add("Mortgage", 540);
    	return hashtable;
        }
    
        static void Main()
        {
    	Hashtable hashtable = GetHashtable();
    
    	// See if the Hashtable contains this key.
    	Console.WriteLine(hashtable.ContainsKey("Perimeter"));
    
    	// Test the Contains method. It works the same way.
    	Console.WriteLine(hashtable.Contains("Area"));
    
    	// Get value of Area with indexer.
    	int value = (int)hashtable["Area"];
    
    	// Write the value of Area.
    	Console.WriteLine(value);
        }
    }
