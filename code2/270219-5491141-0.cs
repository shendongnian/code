    public static int Parse(string s)
    {
        return Number.ParseInt32(s, NumberStyles.Integer, NumberFormatInfo.CurrentInfo);
    }
    internal static unsafe int ParseInt32(string s, NumberStyles style,
        NumberFormatInfo info)
    {
        byte* stackBuffer = stackalloc byte[1 * 0x72];
        NumberBuffer number = new NumberBuffer(stackBuffer);
        int num = 0;
        StringToNumber(s, style, ref number, info, false);
        if ((style & NumberStyles.AllowHexSpecifier) != NumberStyles.None)
        {
            if (!HexNumberToInt32(ref number, ref num))
            {
                throw new OverflowException(Environment.GetResourceString("Overflow_Int32"));
            }
            return num;
        }
        if (!NumberToInt32(ref number, ref num))
        {
            throw new OverflowException(Environment.GetResourceString("Overflow_Int32"));
        }
        return num;
    }
