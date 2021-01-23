    public static class SqlUtils
    {
        public static string StringConvert(double? x)
        {
            return SqlFunctions.StringConvert(x);
        }
        public static string StringConvert(decimal? x)
        {
            return SqlFunctions.StringConvert(x);
        }
    }
