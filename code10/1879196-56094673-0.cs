    public static string ToDecimalString(this BigInteger value)
    {
        if (value == 0) return "0";
        var digits = 10000;
        var divider = BigInteger.Pow(10, digits);
        var parts = new Stack<string>();
        while (true)
        {
            BigInteger remainder;
            value = BigInteger.DivRem(value, divider, out remainder);
            if (value != 0)
            {
                parts.Push(BigInteger.Abs(remainder).ToString().PadLeft(digits, '0'));
            }
            else
            {
                parts.Push(remainder.ToString());
                break;
            }
        }
        return String.Join("", parts);
    }
