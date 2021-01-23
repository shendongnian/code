    public const string FilterDigits = "0123456789";
    public const string FilterLetters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    /// <summary>
    /// Strips away any characters not defined in validChars and returns the result.
    /// </summary>
    public static string FilterTo(string text, string validChars)
    {
	StringBuilder Result = new StringBuilder();
	for (int i = 1; i <= text.Length; i++) {
		char CurrentChar = Convert.ToChar(Strings.Mid(text, i, 1));
		if (validChars.Contains(CurrentChar)) {
			Result.Append(CurrentChar);
		}
	}
	return Result.ToString;
    }
