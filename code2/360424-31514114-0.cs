    public static IEnumerable<string> SplitText(string text, int length)
	{
		for (int i = 0; i < text.Length; i += length)
		{
			yield return text.Substring(i, Math.Min(length, text.Length - i));	
		}
	}
