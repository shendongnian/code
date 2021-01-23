    public static class Int32Extensions
    {
        public static Boolean[] ToBooleanArray(this Int32 i)
        {
            return Convert.ToString(i, 2 /*for binary*/).Select(s => s.Equals('1')).ToArray();
        }
    }
