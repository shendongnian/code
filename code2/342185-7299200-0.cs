	using System.Text.RegularExpressions;
	namespace WindowsFormsApplication1
	{
		public class ParsedInput
		{
			public static readonly Regex RegularExpression = new Regex("{[a-z]*}");
			private MatchCollection matches;
			public ParsedInput(string input)
			{
				matches = RegularExpression.Matches(input);
			}
			public bool TryGetWord(int index, out string word)
			{
				foreach (Match match in matches)
				{
					if (index >= match.Index && index < (match.Index + match.Length))
					{
						word = match.Captures[0].Value;
						return true;
					}
				}
				word = "";
				return false;
			}
		}
	}
