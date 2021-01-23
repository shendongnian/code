	static string parseStringLiteral(string value, ref int ChPosition)
	{
		StringBuilder Value = new StringBuilder();
		char ChCurrent = ElementAtOrDefault(value, ++ChPosition);
		bool goon = true;
		while (goon)
		{
			if (ChCurrent == '"')
			{
				// "" sequence only acceptable
				if (ElementAtOrDefault(value, ChPosition + 1) == '"')
				{
					Value.Append(ChCurrent);
					// skip 2nd double quote
					ChPosition++;
					// move position next
					ChCurrent = ElementAtOrDefault(value, ++ChPosition);
				}
				else goon = false; //break;
			}
			else if (default(Char) == ChCurrent)
			{
				// message: unterminated string
				throw new Exception("ScanningException");
			}
			else
			{
				Value.Append(ChCurrent);
				ChCurrent = ElementAtOrDefault(value, ++ChPosition);
			}
		}
		ChPosition++;
		return Value.ToString();
	}
