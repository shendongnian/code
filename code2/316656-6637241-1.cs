	/// <summary>
		/// checks if a string is null or empty (hasvalue = false if null or empty)
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static bool HasValue(this string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				return false;
			}
			return true;
		}
