    public static class SqlSmallDateTime
    {
        public static readonly SqlDateTime MinValue = 
            new SqlDateTime(new DateTime(1900, 01, 01, 00, 00, 00));
        public static readonly SqlDateTime MaxValue = 
            new SqlDateTime(new DateTime(2079, 06, 06, 23, 59, 00));
    }
