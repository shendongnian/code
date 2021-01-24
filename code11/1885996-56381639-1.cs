	using System;
	using System.Text.RegularExpressions;
	public class Example
	{
	    public static void Main()
	    {
	        string pattern = @"(US|UK|FR)|(CA|NY|IA|TX|MI)|(\d+\/\d+)|\(((.+?)\s+([0-9]+))\)|([A-Z][a-z]{2,}|[A-Z]{3,})|(.*?)";
	        string input = @"US 7/70 MI Construction hrs.
	US IA Private hrs.
	US OIL 8/70 hrs. (Dec 2014)
	UK 7/70 MI Construction hrs.
	UK IA Private hrs.
	UK OIL 8/70 hrs. (Dec 2014)
	FR 7/70 MI Construction hrs.
	FR IA Private hrs.
	FR OIL 8/70 hrs. (Dec 2014)";
	        RegexOptions options = RegexOptions.Multiline;
	        
	        foreach (Match m in Regex.Matches(input, pattern, options))
	        {
	            Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
	        }
	    }
	}
