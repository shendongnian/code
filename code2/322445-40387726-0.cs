		/// <summary>Convert a number into a string of bits</summary>
		/// <param name="value">Value to convert - will get exception</param>
		/// <param name="minBits">Minimum number of bits, usually a multiple of 4</param>
		/// <exception cref="InvalidCastException">Value must be convertible to long</exception>
		/// <exception cref="OverflowException">Value must be convertible to long</exception>
		/// <returns></returns>
		public static string ShowBits<T>(this T value, int minBits)
		{
			long x = Convert.ToInt64(value);
			string retVal = Convert.ToString(x, 2);
			if (retVal.Length > minBits) retVal = Regex.Replace(retVal, @"^1+", "1");	// Replace leading 1s with a single 1 - can pad as needed below
			if (retVal.Length < minBits) retVal = new string(x < 0 ? '1' : '0', minBits - retVal.Length) + retVal;
			return retVal;
		}
