    public static string DoubleToBinaryString(double d)
    {
        return Convert.ToString(BitConverter.DoubleToInt64Bits(d), 2);
    }
    public static double BinaryStringToDouble(string s)
    {
        return BitConverter.Int64BitsToDouble(Convert.ToInt64(s, 2));
    }
