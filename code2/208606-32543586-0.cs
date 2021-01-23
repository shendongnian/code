	/// <summary>
	/// Gets an encoding for the ASCII (7-bit) character set.
	/// </summary>
	/// <see cref="http://stackoverflow.com/a/4022893/1248177"/>
	/// <param name="s">A character set.</param>
	/// <returns>An encoding for the ASCII (7-bit) character set.</returns>
	public static byte[] StringToAscii(string s)
	{
		return (from char c in s select (byte)((c <= 0x7f) ? c : '?')).ToArray();
	}
