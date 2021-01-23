	using System.Text;
	using System.Globalization;
	...
	public static string RemoveDiacritics(this string strThis)
	{
		if (strThis == null)
			return null;
		var sb = new StringBuilder();
		foreach (char c in strThis.Normalize(NormalizationForm.FormD))
		{
			if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
				sb.Append(c);
		}
		return sb.ToString();
	}
