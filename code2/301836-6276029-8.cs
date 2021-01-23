    using System;
    using System.Text.RegularExpressions;			
    public class Program
    {
    	public static void Main()
    	{
    		
    		var tests = new[] {
    			new { Input="abcdef", Search="abc", Replacement="xyz", Expected="xyzdef" },
    			new { Input="ABCdef", Search="abc", Replacement="xyz", Expected="xyzdef" },
    			new { Input="A*BCdef", Search="a*bc", Replacement="xyz", Expected="xyzdef" },
    			new { Input="abcdef", Search="abc", Replacement="x*yz", Expected="x*yzdef" },		
    			new { Input="abcdef", Search="abc", Replacement="$", Expected="$zdef" },
    		};
    		
    		
    		foreach(var test in tests){
    			var result = ReplaceCaseInsensitive(test.Input, test.Search, test.Replacement);
    			
    			Console.WriteLine(
    				"Success: {0}, Actual: {1}, {2}",
    				result == test.Expected,
    				result,
    				test
    			);
    			
    		}
    		
    		
    	}
    	
    	private static string ReplaceCaseInsensitive(string input, string search, string replacement){
    		string result = Regex.Replace(
    			input,
    			Regex.Escape(search), 
    			replacement.Replace("$","$$"), 
    			RegexOptions.IgnoreCase
    		);
    		return result;
    	}
    }
