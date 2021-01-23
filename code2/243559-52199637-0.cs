    public static class ByteExtension
    {
        public static string ToBitsString(this byte value)
        {
            return Convert.ToString(value, 2).PadLeft(8, '0');
        }
    }
