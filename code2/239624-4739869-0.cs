    private static readonly long NegativeZeroBits =
        BitConverter.DoubleToInt64Bits(-0.0);
    public static bool IsNegativeZero(double x)
    {
        return BitConverter.DoubleToInt64Bits(x) == NegativeZeroBits;
    }
