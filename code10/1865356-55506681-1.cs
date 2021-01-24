	public static int GetNum(string s, string prefix, char terminator, int maxCharsToSearch = 10000)
	{
		int numChars = Math.Min(s.Length, maxCharsToSearch);
		for (int i = 0; i < numChars; i++)
		{
			for (int j = 0; j < prefix.Length && j + i < s.Length; j++)
			{
				char c1 = s[j + i];
				char c2 = prefix[j];
				if (c1 == c2)
				{
					if (j == prefix.Length - 1)
					{
						int num = 0;
						for (int k = j + i + 1; k < s.Length && k < j + i + 10; k++)
						{
							char c = s[k];
							if (c == terminator)
							{
								return num;
							}
							num *= 10;
							num += c - 48;
						}
						return -1;
					}
				}
				else
				{
					break;
				}
			}
		}
		return -1;
	}
	
