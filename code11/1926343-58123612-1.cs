    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	private static IEnumerable<string> ParseTokens(string input)
    	{
    		return input
    			// removes the leading {
    			.TrimStart('{')
    			// removes the trailing }
    			.TrimEnd('}')
    			// splits on the different token in the middle
    			.Split( new string[] { "},{" }, StringSplitOptions.None );
    	}
    	
    	public static void Main()
    	{
            var instance = "{112,This is the first day 23/12/2009},{132,This is the second day 24/12/2009}";
    		foreach (var item in ParseTokens( instance ) ) {
    			Console.WriteLine( item );
    		}
    	}
    }
