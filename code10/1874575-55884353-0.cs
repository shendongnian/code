    using System;
    using System.Text.RegularExpressions;
    public class Program
    {
    	public static void Main()
    	{
    		string input = @"
    <garbage>
    Hello world, <rubbish>it's a wonderful day.
    
    
    
    <trash>
    ";
            foreach (Match match in Regex.Matches(input, @"(?<!<[^>]*)[a-zA-Z']+(?![^<]*>)"))
            {
                Console.WriteLine(match.Value);
            }
    	}
    }
