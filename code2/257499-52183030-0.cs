		public static string StripQuotes(string text, char quote, string unescape)a
		{
			string with = quote.ToString();
			if (quote != '\0')
			{
				// check if text contains quote character at all
				if (text.Length >= 2 && text.StartsWith(with) && text.EndsWith(with))
				{
					text = text.Trim(quote);
				}
			}
			if (!string.IsNullOrEmpty(unescape))
			{
				text = text.Replace(unescape, with);
			}
			return text;
		}
