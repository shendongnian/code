		public long GetActualPosition(StreamReader reader)
		{
			// The current buffer of decoded characters
			char[] charBuffer = (char[]) reader.GetType().InvokeMember("charBuffer"
				, System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetField
				, null, reader, null); 
	
			// The current position in the buffer of decoded characters
			int charPos = (int) reader.GetType().InvokeMember("charPos"
				, System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetField
				, null, reader, null);
			// The number of bytes that the already-read characters need when encoded.
			int numReadBytes = reader.CurrentEncoding.GetByteCount(charBuffer, 0, charPos);
			// The number of encoded bytes that are in the current buffer
			int byteLen = (int) reader.GetType().InvokeMember("byteLen"
				, System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetField
				, null, reader, null); 
			return reader.BaseStream.Position - byteLen + numReadBytes;
		}
