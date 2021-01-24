    internal static long DoubleDateToTicks(double value)
        {
            if (!(value < 2958466.0) || !(value > -657435.0))
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_OleAutDateInvalid"));
            }
            long num = (long)(value * 86400000.0 + ((value >= 0.0) ? 0.5 : (-0.5)));
            if (num < 0)
            {
                num -= num % 86400000 * 2;
            }
            num += 59926435200000L;
            if (num < 0 || num >= 315537897600000L)
            {
                throw new ArgumentException(Environment.GetResourceString("Arg_OleAutDateScale"));
            }
            return num * 10000;
        }
