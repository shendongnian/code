    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var input = @"
    using System;
    
    public class ChildClass : BaseClass
    {
    }
    ";
    		var pattern = @"\w+ class \w+ : \w+";
    		var isMatch = Regex.IsMatch(input, pattern);
    		var matches = Regex.Matches(input, pattern);
    		
    		Console.WriteLine(isMatch);
    		Console.WriteLine(matches.Count);
    		Console.WriteLine(matches[0]);
    	}
    }
