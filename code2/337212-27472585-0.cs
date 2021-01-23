	/// <summary>
	/// Removes trailing occurrence(s) of a given string from the current System.String object.
	/// </summary>
	/// <param name="trimSuffix">A string to remove from the end of the current System.String object.</param>
	/// <param name="removeAll">If true, removes all trailing occurrences of the given suffix; otherwise, just removes the outermost one.</param>
	/// <returns>The string that remains after removal of suffix occurrence(s) of the string in the trimSuffix parameter.</returns>
	public static string TrimEnd(this string input, string trimSuffix, bool removeAll = true) {
		while (input != null && trimSuffix != null && input.EndsWith(trimSuffix)) {
			input = input.Substring(0, input.Length - trimSuffix.Length);
			if (!removeAll) {
				return input;
			}
		}
		return input;
	}
