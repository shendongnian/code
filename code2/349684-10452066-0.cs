    public static class StringExtensions
	{
		///----------------------------------------------------------------------
		/// <summary>
		/// Gets the matches between delimiters.
		/// </summary>
		/// <param name="source">The source string.</param>
		/// <param name="beginDelim">The beginning string delimiter.</param>
		/// <param name="endDelim">The end string delimiter.</param>
		/// <returns></returns>
		/// <example>
		/// string beginDelim = "<span>";
		///	string endDelim = "</span>";
		///	string input = string.Format("My Name is {0}Lance{1} and I am {0}39{1} years old", beginDelim, endDelim);
		///
		///	var values = input.GetMatches(beginDelim, endDelim);
		///	foreach (string value in values)
		///	{
		///		Console.WriteLine(value);
		///	}
		/// </example>
		///----------------------------------------------------------------------
		public static IEnumerable<string> GetMatches(this string source, string beginDelim, string endDelim)
		{
			Regex reg = new Regex(string.Format("(?<={0}).*(?={1})", beginDelim, endDelim));
			MatchCollection matches = reg.Matches(source);
			return (from Match m in matches select m.Value).ToList();
		}
	}
