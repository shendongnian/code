	// @struct IEEE_DOUBLEREP | allows bit access to 8 byte floats
	//[StructLayout(LayoutKind.Sequential)]
	//public struct ieee_doublerep
	//{
	//    ulong low_mantissa;		// @field low 16 bits of mantissa
	//    ushort mid_mantissa;	// @field mid 16 bits of mantissa
	//    uint high_mantissa:4;		// @field high 4 bits of mantissa
	//    uint exponent:11;			// @field exponent of floating point number
	//    uint sign:1;				// @field sign of floating point number
	//};
 
	public struct DoubleEx
	{
		public const long NANMASK = 0x7FF0000000000000;
		public const long INFINITYMASK = 0x000FFFFFFFFFFFFF;
 
		public const double NaN = 0.0f / 0.0f;
		public const double NegativeInfinity = -1.0f / 0.0f;
		public const double PositiveInfinity = 1.0f / 0.0f;
		public static bool IsNaNBad(double x)
		{
			return x != x;
		}
 
		public unsafe static bool IsNaN(double value)        
		{
			long rep = *((long*)&value);
			return ((rep & NANMASK) == NANMASK &&
					((rep & INFINITYMASK) != 0));
		}
 
		public unsafe static bool IsPositiveInfinity(double value)
		{
			double negInf = DoubleEx.PositiveInfinity;
			return *((long*)&value) == *((long*)&negInf);
		}
 
		public unsafe static bool IsNegativeInfinity(double value)
		{
			double posInf = DoubleEx.PositiveInfinity;
			return *((long*)&value) == *((long*)&posInf);
		}
 
		public unsafe static bool IsInfinite(double x)
		{
			long rep = *((long*)&x);
			return ((rep & NANMASK) == NANMASK &&
					((rep & INFINITYMASK) == 0));
		}
	}
 
