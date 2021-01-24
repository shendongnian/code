    using System;
    using System.Text.RegularExpressions;
    
    public class Simple
    {
    	static string StripLinefeeds(Match m)
    	{
    		string x = m.ToString(); // Get the matched string.
    		return x.Replace("\n", "");
    	}
    
    	public static void Main()
    	{
    		Regex re = new Regex(@""".+?""", RegexOptions.Singleline);
    		MatchEvaluator me = new MatchEvaluator(StripLinefeeds);		
    		string text = "\n\"this is some text \n this should not be on the new line\"";
    		Console.WriteLine(text);
    		text = re.Replace(text, me);
    		Console.WriteLine(text);
    		text = "\n\"this is some \n text \n\n\n this should not be \n\n on the new line\"";
    		Console.WriteLine(text);
    		text = re.Replace(text, me);
    		Console.WriteLine(text);
    	}
    }
