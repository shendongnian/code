	public static string CleanBadwordsFromString(string text)
	{
		var badWords =
			"bunch,of,words,that,do,not,need,to,be,seen"
				.Split(',').Select(w => w.ToLowerInvariant()).ToArray();
	
		var query =
			from i in Enumerable.Range(0, text.Length)
			let rl = text.Length - i
			from bw in badWords
			let part = text
				.Substring(i, Math.Min(rl, bw.Length))
			where bw == part.ToLowerInvariant()
			select new
			{
				Index = i,
				Replacement = part
					.Substring(0, 1)
					.PadRight(part.Length, '*')
					.ToCharArray(),
			};
	
		var textChars = text.ToCharArray();
	
		foreach (var x in query)
		{
			Array.Copy(
				x.Replacement, 0,
				textChars, x.Index, x.Replacement.Length);
		}
		
		return new String(textChars);
	}
