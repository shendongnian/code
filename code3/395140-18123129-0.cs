    public static class DateTimeExtension
    {
        public static int GetQuarter(this DateTime dateTime)
        {
            if (dateTime.Month <= 3)
                return 1;
            if (dateTime.Month <= 6)
                return 2;
            if (dateTime.Month <= 9)
                return 3;
            return 4;
        }
    }
