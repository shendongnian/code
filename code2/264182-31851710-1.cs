    public static int GetHowManyTimeOccurenceCharInString(string text, char c)
	{
		int count = 0;
		foreach(char ch in text)
		{
			if(ch.Equals(c))
			{
				count++;
			}
		}
		return count;
	}
