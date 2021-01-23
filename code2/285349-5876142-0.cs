		private byte[] translateInto866(string fileName)
		{
			const byte startCode1 = 128;		// А, 0410
			const byte startCode2 = 224;		// р, 0440
			var result = new byte[fileName.Length];
			int i = 0;
			foreach (char c in fileName)
			{
				if (c >= 'А' && c <= 'п')
				{
					result[i] = (byte)(((byte)(c - 'А')) + startCode1);
				}
				else if (c > 'п' && c <= 'я')
				{
					result[i] = (byte)(((byte)(c - 'р')) + startCode2);
				}
				else
				{
					result[i] = (byte) c;
				}
				i++;
			}
			return result;
		}
