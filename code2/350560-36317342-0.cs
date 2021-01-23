	/// <summary>
	/// Get the Nth field of a string, where fields are delimited by some substring.
	/// </summary>
	/// <param name="str">string to search in</param>
	/// <param name="index">0-based index of field to get</param>
	/// <param name="separator">separator substring</param>
	/// <returns>Nth field, or null if out of bounds</returns>
	public static string NthField(this string str, int index, string separator=" ") {
		int count = 0;
		int startPos = 0;
		while (startPos < str.Length) {
			int endPos = str.IndexOf(separator, startPos);
			if (endPos < 0) endPos = str.Length;
			if (count == index) return str.Substring(startPos, endPos-startPos);
			count++;
			startPos = endPos + separator.Length;
		}
		return null;
	}	
