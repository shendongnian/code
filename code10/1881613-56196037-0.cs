	public static bool GetString(XmlNode node, string ID, Action<string> action)
	{
		string result = null;
		bool bl = GetString(node, ID, ref result);
		if (bl)
		{
			action(result);
		}
		return bl;
	}
	
	public static bool GetInt(XmlNode node, string ID, Action<int?> action)
	{
		int? result = null;
		bool bl = GetInt(node, ID, ref result);
		if (bl)
		{
			action(result);
		}
		return bl;
	}
