		/// <summary>
		/// Determines if any invalid XML 1.0 characters exist within the string,
		/// and if so it returns a new string with the invalid chars removed, else 
		/// the same string is returned (with no wasted StringBuilder allocated, etc).
		/// </summary>
		/// <param name="s">Xml string.</param>
		/// <param name="startIndex">The index to begin checking at.</param>
		public static string ToValidXmlCharactersString(string s, int startIndex = 0)
		{
			int firstInvalidChar = IndexOfFirstInvalidXMLChar(s, startIndex);
			if (firstInvalidChar < 0)
				return s;
			startIndex = firstInvalidChar;
            int len = s.Length;
			var sb = new StringBuilder(len);
			if (startIndex > 0)
				sb.Append(s, 0, startIndex);
			for (int i = startIndex; i < len; i++)
				if (IsLegalXmlChar(s[i]))
					sb.Append(s[i]);
			return sb.ToString();
		}
		/// <summary>
		/// Gets the index of the first invalid XML 1.0 character in this string, else returns -1.
		/// </summary>
		/// <param name="s">Xml string.</param>
		/// <param name="startIndex">Start index.</param>
		public static int IndexOfFirstInvalidXMLChar(string s, int startIndex = 0)
		{
			if (s != null && s.Length > 0 && startIndex < s.Length) {
				if (startIndex < 0) startIndex = 0;
				int len = s.Length;
				for (int i = startIndex; i < len; i++)
					if (!IsLegalXmlChar(s[i]))
						return i;
			}
			return -1;
		}
		
		/// <summary>
		/// Indicates whether a given character is valid according to the XML 1.0 spec.
		/// This code represents an optimized version of Tom Bogle's on SO: 
		/// http://stackoverflow.com/a/13039301/264031.
		/// </summary>
		public static bool IsLegalXmlChar(char c)
		{
			if (c > 31 && c <= 55295)
				return true;
			if (c < 32)
				return c == 9 || c == 10 || c == 13;
			return (c >= 57344 && c <= 65533) || c > 65535;
			// final comparison is useful only for integral comparison, if char c -> int c, useful for utf-32 I suppose
			//c <= 1114111 */ // impossible to get a code point bigger than 1114111 because Char.ConvertToUtf32 would have thrown an exception
		}
