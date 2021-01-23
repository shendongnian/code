	// Awful name, obviously.
	public static string TakeSkipTakeEtc(this string source, params char[] tokens)
	{
		bool taking = true;
		
		int startIndex = 0;
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char token in tokens)
		{
			int index = source.IndexOf(token, startIndex);
			if (index == -1)
			{
				if (taking)
				{
					stringBuilder.Append(source.Substring(startIndex));
				}
				
				return stringBuilder.ToString();
			}
			
			if (taking)
			{
				int length = index + 1 - startIndex;
				stringBuilder.Append(source.Substring(startIndex, length));
			}
			
			startIndex = index + 1;
			taking = !taking;
		}
		
		return stringBuilder.ToString();
	}
