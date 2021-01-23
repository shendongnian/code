	static string getNumber(String str)
	{
		StringBuilder sb = new StringBuilder();
		foreach (char chr in str)
		{
			try
			{
				int x = int.Parse(chr.ToString());
				sb.Append(chr);
			} catch (Exception ex) {
				return sb.ToString();
			}
		}
		return null;
	}
	static string getCode(String str)
	{
		StringBuilder sb = new StringBuilder();
		foreach (char chr in str)
		{
			try
			{
				int x = int.Parse(chr.ToString());
			}
			catch (Exception ex)
			{
				sb.Append(chr);
			}
		}
		return sb.ToString();
	}
    // 95
	Console.WriteLine(getNumber("95d"));
    // a
	Console.WriteLine(getCode("95d"));
