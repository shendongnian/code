    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
    	public static void Main()
    	{
    		string input = @"(a>da <asd> fds&sd fsdf%dsf;sd f=sdf{sdf} asd(as)dfs";
    		// NOTE: REPLACE the pattern with the one you need
    		string pattern = @"<|>|&|%|;|=|{|}|\(|\)";
    		string replacement = "";
    		string result = Regex.Replace(input, pattern, replacement);
    
    		Console.WriteLine("Original String: {0}", input);
    		Console.WriteLine("Replacement String: {0}", result);                             
    	}
    }
