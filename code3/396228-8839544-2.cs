    public static String ParseString(String value){...}
	//From
	public static String ParseString(String value)
	{
		if ((value.StartsWith("\"")) & (value.EndsWith("\"")) || (value.StartsWith("'")) & (value.EndsWith("'")))
		{
			if (value.Length > 1)
			{				
				if (value.IndexOf('\\') != -1)
				{
					return Unescape(value.Substring(1, value.Length - 2));
				}
				
				return value.Substring(1, value.Length - 2);
			}
		}
		throw new ArgumentException("String value of '" + value + "' cannot be parsed");
	}	
	
	//To
	public static String ParseString(String value, bool requireUnescape = true)
	{
		if ((value.StartsWith("\"")) & (value.EndsWith("\"")) || (value.StartsWith("'")) & (value.EndsWith("'")))
		{
			if (value.Length > 1)
			{
				if (requireUnescape)
				{
					if (value.IndexOf('\\') != -1)
					{
						return Unescape(value.Substring(1, value.Length - 2));
					}
				}
				return value.Substring(1, value.Length - 2);
			}
		}
		throw new ArgumentException("String value of '" + value + "' cannot be parsed");
	}	
