    struct Date
        {
            public static double GetTime(DateTime dateTime)
            {
                return dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            }
    
            public static DateTime DateTimeParse(double milliseconds)
            {
                return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(milliseconds).ToLocalTime();
            }
    
        }
