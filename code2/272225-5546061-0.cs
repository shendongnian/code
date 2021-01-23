	public static string RemoveDiacritics(this string input)
	{
		input = input.Normalize(NormalizationForm.FormD);
		StringBuilder output = new StringBuilder();
		for (int i = 0; i < input.Length; i++)
		{
			if (CharUnicodeInfo.GetUnicodeCategory(input[i]) != UnicodeCategory.NonSpacingMark) 
				output.Append(input[i]);
		}
		return output.ToString();
	}
