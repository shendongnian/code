    // input is the input string to split
	// limit is the number of desired substrings to output
	public static IEnumerable<string> ReverseSplit(string input, int limit = 7)
	{
		var temp = new StringBuilder();
		
        // start from the end of the input and loop backward, character by character
		for (int i = input.Length - 1; i >= 0; i--)
		{
            // If we find a '_' and we haven't reached the limit of the split,
            // we can yield return the current substring
			if (input[i] == '_' && limit > 1)
			{
				yield return temp.ToString();
				temp.Clear();
				limit--;
			}
			else // Else, just insert the current character at the begining of the current substring
			{
				temp.Insert(0, input[i]);
			}
		}
		
        // return the last element
		if (temp.Length > 0)
			yield return temp.ToString();
	}
