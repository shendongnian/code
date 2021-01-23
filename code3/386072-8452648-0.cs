		static private IList<string> SplitString(string str)
		{
			List<string> lines = new List<string>();
			StringBuilder line = new StringBuilder();
			for(int i = 0; i < str.Length; ++i)
			{
				if (char.IsWhiteSpace(str[i]))
				{
					// split silently at whitespace
					if (line.Length > 0)
						lines.Add(line.ToString());
					line.Clear();
				}
				else if (IsPunctuationCharacter(str[i]))
				{
					// split for punctuation and include each punctuation character as its own line
					if (line.Length > 0)
						lines.Add(line.ToString());
					lines.Add(new string(new char[] { str[i] }));
					line.Clear();
				}
				else
				{
					// all other characters get added to the current line
					line.Append(str[i]);
				}
			}
			if (line.Length > 0)
				lines.Add(line.ToString());
			return lines;
		}
		static private bool IsPunctuationCharacter(char c)
		{
			if (c == ',' || c == '.' || c == '?' || c == '!')
				return true;
			else
				return false;
		}
