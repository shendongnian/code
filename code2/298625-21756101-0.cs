    	public static string Upper_To_Lower(string text)
		{
			if (Char.IsUpper(text[0]) == true) { text = text.Replace(text[0], char.ToLower(text[0])); return text; }
			return text;
		}
		public static string Lower_To_Upper(string text)
		{
			if (Char.IsLower(text[0]) == true) { text = text.Replace(text[0], char.ToUpper(text[0])); return text; }
			return text;
		}
