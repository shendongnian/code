	public static int? SplitReverseInt(this string str, int ixFromBack)
	{
		var inWord = false;
		var wEnd = 0;
		var found = 0;
		for (int i = str.Length - 1; i >= 0; i--)
		{
			var charr = str[i];
			if (char.IsWhiteSpace(charr))
			{
				// we found the beginning of a word
				if (inWord)
				{
					if (found == ixFromBack)
					{
						var myInt = 0;
						for (int j = i+1; j <= wEnd; j++)
							myInt = (myInt * 10 + str[j] - '0');
						return myInt;
					}
					inWord = false;
					found++;
				}
			}
			else
			{
				if (!inWord)
				{
					wEnd = i;
					inWord = true;
				}
			}
		}
		// word (number) is at the beginning of the string
		if (inWord && found == ixFromBack)
		{
			var myInt = 0;
			for (int j = 0; j <= wEnd; j++)
				myInt = (myInt * 10 + str[j] - '0');
			return myInt;
		}
		return null;
	}
	
