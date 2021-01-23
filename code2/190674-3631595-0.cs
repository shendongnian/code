	public static string ClearHTML(string Str, Nullable<int> Character)
	{
		string MetinTxtRegex = Regex.Replace(Str, "<(.|\n)+?>", " ");
		string MetinTxtSubStr = string.Empty;
		if (Character.HasValue)
		{
			if (MetinTxtRegex.Length > Character)
			{
				MetinTxtSubStr = MetinTxtRegex.Substring(0, Character.Value);
				MetinTxtSubStr = MetinTxtSubStr.Substring(0, MetinTxtSubStr.LastIndexOf(" ")) + "...";
			}
			else
			{
				MetinTxtSubStr = MetinTxtRegex;
			}
		}
		else
		{
			MetinTxtSubStr = MetinTxtRegex;
		}
		return MetinTxtSubStr;
	}
