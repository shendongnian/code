		public long GetActualPosition(StreamReader reader)
		{
			int charPos = (int) reader.GetType().InvokeMember("charPos"
				, System.Reflection.BindingFlags.DeclaredOnly 
					| System.Reflection.BindingFlags.NonPublic 
					| System.Reflection.BindingFlags.Instance 
					| System.Reflection.BindingFlags.GetField
				, null, reader, null); 
			int charLen = (int) reader.GetType().InvokeMember("charLen"
				, System.Reflection.BindingFlags.DeclaredOnly 
					| System.Reflection.BindingFlags.NonPublic 
					| System.Reflection.BindingFlags.Instance 
					| System.Reflection.BindingFlags.GetField
				, null, reader, null); 
			return reader.BaseStream.Position - charLen + charPos;
		}
