    const decimal DecimalEpsilon = 0.0000000000000000000000000001M;
    public static decimal TryToDecimalWithInsignificand(double dbl, out bool succeeded)
    {
        if (double.IsPositiveInfinity(dbl))
        {
            succeeded = false;
            return decimal.MaxValue;
        }
        if (double.IsNegativeInfinity(dbl))
        {
            succeeded = false;
            return decimal.MinValue;
        }
        if (double.IsNaN(dbl))
        {
            succeeded = false;
            return 0M;
        }
        if (dbl > (double)decimal.MaxValue)
        {
            succeeded = false;
            return decimal.MaxValue;
        }
        if (dbl < (double)decimal.MinValue)
        {
            succeeded = false;
            return decimal.MinValue;
        }
        if (dbl > 0.0 && dbl <= (double)DecimalEpsilon)
        {
            succeeded = false;
            return 0M;
        }
        if (dbl < 0.0 && dbl >= (double)-DecimalEpsilon)
        {
            succeeded = false;
            return 0M;
        }
        // start conversion
        long bits = BitConverter.DoubleToInt64Bits(dbl);
        long mantissa = bits & 0xFFFFFFFFFFFFFL;        // 52 bits
        long exponent = ((bits >> 52) & 0x7FFL) - 1023L;    // next 11 bits
        bool negative = bits < 0;
        decimal fraction = mantissa / (decimal)0x10000000000000L;
        decimal result;
        if (exponent < 0)
        {
            long div = 1 << (int)-exponent;
            result = (fraction + 1) / div;
        }
        else
        {
            long mul = 1L << (int)exponent;
            result = (fraction + 1) * mul;
        }
        succeeded = true;
        return result;
    }
