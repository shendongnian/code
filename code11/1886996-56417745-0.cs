	using System;
	using System.Text.RegularExpressions;
	public class Example
	{
	    public static void Main()
	    {
	        string pattern = @">>>(.+)\s*(.+)\s*<<<.+";
	        string input = @">>>tagA
				contents 1
				<<<tagA
				>>>tagB
				contents 2
				<<<tagB
				>>>tagC
				contents 2
	<<<tagC
	";
	        RegexOptions options = RegexOptions.Multiline;
	        
	        foreach (Match m in Regex.Matches(input, pattern, options))
	        {
	            Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
	        }
	    }
	}
