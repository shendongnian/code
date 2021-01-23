    /// <summary>
	/// A set of extensions to allow the convenient comparison of float values based on a given precision.
	/// </summary>
	public static class FloatingPointExtensions
	{
		/// <summary>
		/// Determines if the float value is less than or equal to the float parameter according to the defined precision.
		/// </summary>
		/// <param name="float1">The float1.</param>
		/// <param name="float2">The float2.</param>
		/// <param name="precision">The precision.  The number of digits after the decimal that will be considered when comparing.</param>
		/// <returns></returns>
		public static bool LessThan(this float float1, float float2, int precision)
		{
			return (System.Math.Round(float1 - float2, precision) < 0);
		}
		/// <summary>
		/// Determines if the float value is less than or equal to the float parameter according to the defined precision.
		/// </summary>
		/// <param name="float1">The float1.</param>
		/// <param name="float2">The float2.</param>
		/// <param name="precision">The precision.  The number of digits after the decimal that will be considered when comparing.</param>
		/// <returns></returns>
		public static bool LessThanOrEqualTo(this float float1, float float2, int precision)
		{
			return (System.Math.Round(float1 - float2, precision) <= 0);
		}
		/// <summary>
		/// Determines if the float value is greater than (>) the float parameter according to the defined precision.
		/// </summary>
		/// <param name="float1">The float1.</param>
		/// <param name="float2">The float2.</param>
		/// <param name="precision">The precision.  The number of digits after the decimal that will be considered when comparing.</param>
		/// <returns></returns>
		public static bool GreaterThan(this float float1, float float2, int precision)
		{
			return (System.Math.Round(float1 - float2, precision) > 0);
		}
		/// <summary>
		/// Determines if the float value is greater than or equal to (>=) the float parameter according to the defined precision.
		/// </summary>
		/// <param name="float1">The float1.</param>
		/// <param name="float2">The float2.</param>
		/// <param name="precision">The precision.  The number of digits after the decimal that will be considered when comparing.</param>
		/// <returns></returns>
		public static bool GreaterThanOrEqualTo(this float float1, float float2, int precision)
		{
			return (System.Math.Round(float1 - float2, precision) >= 0);
		}
		/// <summary>
		/// Determines if the float value is equal to (==) the float parameter according to the defined precision.
		/// </summary>
		/// <param name="float1">The float1.</param>
		/// <param name="float2">The float2.</param>
		/// <param name="precision">The precision.  The number of digits after the decimal that will be considered when comparing.</param>
		/// <returns></returns>
		public static bool AlmostEquals(this float float1, float float2, int precision)
		{
			return (System.Math.Round(float1 - float2, precision) == 0);
		} 
	}
