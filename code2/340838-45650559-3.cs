	public static void MultiReplace(this StringBuilder builder, 
		char[] toReplace,
		char replacement)
	{
		var set = new bool[256];
		foreach (var charToReplace in toReplace)
		{
			set[charToReplace] = true;
		}
		for (int i = 0; i < builder.Length; ++i)
		{
			var currentCharacter = builder[i];
			if (set[currentCharacter])
			{
				builder[i] = replacement;
			}
		}
	}
