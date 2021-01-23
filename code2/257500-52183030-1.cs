	using System;
						
	public class Program
	{
		public static void Main()
		{
			string text = @"""Hello World!""";
			Console.WriteLine(text);
			// That will do the job
			// Output: Hello World!
			string strippedText = text.Trim('"');
			Console.WriteLine(strippedText);
			
			string escapedText = @"""My name is \""Bond\"".""";
			Console.WriteLine(escapedText);
			// That will *NOT* do the job to good
			// Output: My name is \"Bond\".
			string strippedEscapedText = escapedText.Trim('"');
			Console.WriteLine(strippedEscapedText);
			
			// Allow to use \" inside quoted text
			// Output: My name is "Bond".
			string strippedEscapedText2 = escapedText.Trim('"').Replace(@"\""", @"""");
			Console.WriteLine(strippedEscapedText2);
			
			// Create a function that will check texts for having or not
			// having citation marks and unescapes text if needed.
			string t1 = @"""My name is \""Bond\"".""";
			// Output: "My name is \"Bond\"."
			Console.WriteLine(t1);
			// Output: My name is "Bond".
			Console.WriteLine(StripQuotes(t1, '"', @"\"""));
			string t2 = @"""My name is """"Bond"""".""";
			// Output: "My name is ""Bond""."
			Console.WriteLine(t2);
			// Output: My name is "Bond".
			Console.WriteLine(StripQuotes(t2, '"', @""""""));
		}
	}
