	/// <summary>
	/// Gets the four character string representation of the specified integer id.
	/// </summary>
	/// <param name="number">The number to convert</param>
	/// <param name="ascending">Indicates whether the encoded number will be sorted ascending or descending</param>
	/// <returns>The encoded string representation of the number</returns>
	public static string NumberToId(int number, bool ascending = true)
	{
		if (!ascending)
			number = 16777215 - number;
		return new string(new[] { 
			SixBitToChar((byte)((number & 16515072) >> 18)), 
			SixBitToChar((byte)((number & 258048) >> 12)), 
			SixBitToChar((byte)((number & 4032) >> 6)), 
			SixBitToChar((byte)(number & 63)) });
	}
	/// <summary>
	/// Gets the numeric identifier represented by the encoded string.
	/// </summary>
	/// <param name="id">The encoded string to convert</param>
	/// <param name="ascending">Indicates whether the encoded number is sorted ascending or descending</param>
	/// <returns>The decoded integer id</returns>
	public static int IdToNumber(string id, bool ascending = true)
	{
		var number = ((int)CharToSixBit(id[0]) << 18) | ((int)CharToSixBit(id[1]) << 12) | ((int)CharToSixBit(id[2]) << 6) | (int)CharToSixBit(id[3]);
		return ascending ? number : -1 * (number - 16777215);
	}
	/// <summary>
	/// Converts the specified byte (representing 6 bits) to the correct character representation.
	/// </summary>
	/// <param name="b">The bits to convert</param>
	/// <returns>The encoded character value</returns>
	[MethodImplAttribute(MethodImplOptions.AggressiveInlining)] 
	static char SixBitToChar(byte b)
	{
		if (b == 0)
			return '!';
		if (b == 1)
			return '$';
		if (b < 12)
			return (char)((int)b - 2 + (int)'0');
		if (b < 38)
			return (char)((int)b - 12 + (int)'A');
		return (char)((int)b - 38 + (int)'a');
	}
		
	/// <summary>
	/// Coverts the specified encoded character into the corresponding bit representation.
	/// </summary>
	/// <param name="c">The encoded character to convert</param>
	/// <returns>The bit representation of the character</returns>
	[MethodImplAttribute(MethodImplOptions.AggressiveInlining)] 
	static byte CharToSixBit(char c)
	{
		if (c == '!')
			return 0;
		if (c == '$')
			return 1;
		if (c <= '9')
			return (byte)((int)c - (int)'0' + 2);
		if (c <= 'Z')
			return (byte)((int)c - (int)'A' + 12);
		return (byte)((int)c - (int)'a' + 38);
	}
