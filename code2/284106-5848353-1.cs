    using System;
    
    class Program
    {
        static void Main()
        {
    	Test("Dot Net Perls");
    	Test("dot net perls");
        }
    
        static void Test(string input)
        {
    	Console.Write("--- ");
    	Console.Write(input);
    	Console.WriteLine(" ---");
    	//
    	// See if the string contains 'Net'
    	//
    	bool contains = input.Contains("Net");
    	//
    	// Write the result
    	//
    	Console.Write("Contains 'Net': ");
    	Console.WriteLine(contains);
    	//
    	// See if the string contains 'perls' lowercase
    	//
    	if (input.Contains("perls"))
    	{
    	    Console.WriteLine("Contains 'perls'");
    	}
    	//
    	// See if the string contains 'Dot'
    	//
    	if (!input.Contains("Dot"))
    	{
    	    Console.WriteLine("Doesn't Contain 'Dot'");
    	}
        }
    }
