		public static string GetVersion(DateTime dateTime)
		{
			System.TimeSpan timeDifference = dateTime - new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			long min = System.Convert.ToInt64(timeDifference.TotalMinutes);
			return EncodeTo64Url(min);
		}
		public static string EncodeTo64Url(long toEncode)
		{
			string returnValue = EncodeTo64(toEncode);
			// returnValue is base64 = may contain a-z, A-Z, 0-9, +, /, and =.
			// the = at the end is just a filler, can remove
			// then convert the + and / to "base64url" equivalent
			//
			returnValue = returnValue.TrimEnd(new char[] { '=' });
			returnValue = returnValue.Replace("+", "-");
			returnValue = returnValue.Replace("/", "_");
			return returnValue;
		}
		public static string EncodeTo64(long toEncode)
		{
			byte[] toEncodeAsBytes = System.BitConverter.GetBytes(toEncode);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(toEncodeAsBytes);
			string returnValue = System.Convert.ToBase64String(toEncodeAsBytes.SkipWhile(b=>b==0).ToArray());
			return returnValue;
		}
