    public static Fraction RealToFraction(double value, int maxDenominator)
    {
        // http://www.ics.uci.edu/~eppstein/numth/frap.c
        // Find rational approximation to given real number
        // David Eppstein / UC Irvine / 8 Aug 1993
        // With corrections from Arno Formella, May 2008
        if (value == 0.0)
        {
            return new Fraction(0, 1);
        }
        int sign = Math.Sign(value);
        if (sign == -1)
        {
            value = Math.Abs(value);
        }
        int[,] m = { { 1, 0 }, { 0, 1 } };
        int ai = (int) value;
        // Find terms until denominator gets too big
        while (m[1, 0] * ai + m[1, 1] <= maxDenominator)
        {
            int t = m[0, 0] * ai + m[0, 1];
            m[0, 1] = m[0, 0];
            m[0, 0] = t;
            t = m[1, 0] * ai + m[1, 1];
            m[1, 1] = m[1, 0];
            m[1, 0] = t;
            value = 1.0 / (value - ai);
            // 0x7FFFFFFF = Assumes 32 bit floating point just like in the C implementation.
            // This check includes Double.IsInfinity(). Even though C# double is 64 bits,
            // the algorithm sometimes fails when trying to increase this value too much. So
            // I kept it. Anyway, it works.
            if (value > 0x7FFFFFFF)
            {                    
                break;
            }
            ai = (int) value;
        }
        // Two approximations are calculated: one on each side of the input
        // The result of the first one is the current value. Below the other one
        // is calculated and it is returned.
        ai = (maxDenominator - m[1, 1]) / m[1, 0];
        m[0, 0] = m[0, 0] * ai + m[0, 1];
        m[1, 0] = m[1, 0] * ai + m[1, 1];
        return new Fraction(sign * m[0, 0], m[1, 0]);
    }
    public static Fraction RealToFraction(double value, double error)
    {
        if (error <= 0.0 || error >= 1)
        {
            throw new ArgumentOutOfRangeException("error", "Must be between 0 and 1 (exclusive).");
        }
        int maxDenominator = (int) Math.Ceiling(Math.Abs(1.0 / (value * error)));
        if (maxDenominator < 1)
        {
            maxDenominator = 1;
        }
        return RealToFraction(value, maxDenominator);
    }
