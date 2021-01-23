	public static string ReadLimited(int limit)
	{
		string str = string.Empty;
		while (true)
		{
			char c = Console.ReadKey(true).KeyChar;
			if (c == '\r')
				break;
			if (c == '\b' && str != "")
			{
				str = str.Substring(0, str.Length - 1);
				Console.Write("\b \b");
			}
			else if (str.Length < limit)
			{
				Console.Write(c);
				str += c;
			}
		}
		return str;
	}
