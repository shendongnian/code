	using System;
	using System.Text.RegularExpressions;
	public class Test
	{
		public static void Main()
		{
			string input = "doin' some replacement";
			string pattern = @"\bdoin'\b";
			string replace = "doing";
			string result = Regex.Replace(input, pattern, replace);
			Console.WriteLine(result);
		}
	}
