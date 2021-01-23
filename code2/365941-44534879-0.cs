    public static class ObjectExtension
	{
		#region Public Methods
		public static bool ExEquals<T>(this T obj, T objToCompare)
		{
			if (typeof(T) == typeof(string))
				return StringExtension.ExEquals(obj as string, objToCompare as string);
			return obj.Equals(objToCompare);
		}
		public static bool ExHasAllEquals<T>(this T obj, params T[] objArgs)
		{
			for (int index = 0; index < objArgs.Length; index++)
				if (ExEquals<T>(obj, objArgs[index]) == false) return false;
			return true;
		}
		public static bool ExHasEquals<T>(this T obj, params T[] objArgs)
		{
			for (int index = 0; index < objArgs.Length; index++)
				if (ExEquals<T>(obj, objArgs[index])) return true;
			return false;
		}
		public static bool ExHasNoEquals<T>(this T obj, params T[] objArgs)
		{
			return ExHasEquals<T>(obj, objArgs) == false;
		}
		public static bool ExHasNotAllEquals<T>(this T obj, params T[] objArgs)
		{
			for (int index = 0; index < objArgs.Length; index++)
				if (ExEquals<T>(obj, objArgs[index])) return false;
			return true;
		}
		public static bool ExIsNone(this object obj)
		{
			if (obj == null) return true;
			if (obj.Equals(DBNull.Value)) return true;
			return false;
		}
		public static bool ExNotEquals<T>(this T obj, T objToCompare)
		{
			return ExEquals<T>(obj, objToCompare) == false;
		}
		#endregion Public Methods
	}
	public static class StringExtension
	{
		#region Public Methods
		public static bool ExContains(this string fullText, string value)
		{
			return ExIndexOf(fullText, value) > -1;
		}
		public static bool ExEquals(this string text, string textToCompare)
		{
			return text.Equals(textToCompare, StringComparison.OrdinalIgnoreCase);
		}
		public static bool ExHasAllEquals(this string text, params string[] textArgs)
		{
			for (int index = 0; index < textArgs.Length; index++)
				if (ExEquals(text, textArgs[index]) == false) return false;
			return true;
		}
		public static bool ExHasEquals(this string text, params string[] textArgs)
		{
			for (int index = 0; index < textArgs.Length; index++)
				if (ExEquals(text, textArgs[index])) return true;
			return false;
		}
		public static bool ExHasNoEquals(this string text, params string[] textArgs)
		{
			return ExHasEquals(text, textArgs) == false;
		}
		public static bool ExHasNotAllEquals(this string text, params string[] textArgs)
		{
			for (int index = 0; index < textArgs.Length; index++)
				if (ExEquals(text, textArgs[index])) return false;
			return true;
		}
		/// <summary>
		/// Reports the zero-based index of the first occurrence of the specified string
		/// in the current System.String object using StringComparison.InvariantCultureIgnoreCase.
		/// A parameter specifies the type of search to use for the specified string.
		/// </summary>
		/// <param name="fullText">
		/// The string to search inside.
		/// </param>
		/// <param name="value">
		/// The string to seek.
		/// </param>
		/// <returns>
		/// The index position of the value parameter if that string is found, or -1 if it
		/// is not. If value is System.String.Empty, the return value is 0.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// fullText or value is null.
		/// </exception>
		public static int ExIndexOf(this string fullText, string value)
		{
			return fullText.IndexOf(value, StringComparison.OrdinalIgnoreCase);
		}
		public static bool ExNotEquals(this string text, string textToCompare)
		{
			return ExEquals(text, textToCompare) == false;
		}
		#endregion Public Methods
	}
