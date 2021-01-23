	public long GetActualPosition(StreamReader reader)
	{
		System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetField;
		// The current buffer of decoded characters
		char[] charBuffer = (char[])reader.GetType().InvokeMember("charBuffer", flags, null, reader, null);
		// The index of the next char to be read from charBuffer
		int charPos = (int)reader.GetType().InvokeMember("charPos", flags, null, reader, null);
		// The number of decoded chars presently used in charBuffer
		int charLen = (int)reader.GetType().InvokeMember("charLen", flags, null, reader, null);
		// The number of bytes read while advancing reader.BaseStream.Position to (re)fill charBuffer
		int byteLen = (int)reader.GetType().InvokeMember("byteLen", flags, null, reader, null);
		// The number of bytes that the already-read characters need when encoded.
		int numReadBytes = reader.CurrentEncoding.GetByteCount(charBuffer, 0, charPos);
		// The total number of bytes actually needed for the characters currently used in charBuffer
		int totalCharBytes = reader.CurrentEncoding.GetByteCount(charBuffer, 0, charLen);
		if (totalCharBytes > byteLen) // account for the inclusion of a multi-byte char that was bisected
			byteLen = totalCharBytes;
		return reader.BaseStream.Position - byteLen + numReadBytes;
	}
