        public static DateTime TruncateTo(this DateTime dt, DateTruncate TruncateTo)
        {
            if (TruncateTo == DateTruncate.Year)
                return new DateTime(dt.Year, 0, 0);
            else if (TruncateTo == DateTruncate.Month)
                return new DateTime(dt.Year, dt.Month, 0);
            else if (TruncateTo == DateTruncate.Day)
                return new DateTime(dt.Year, dt.Month, dt.Day);
            else if (TruncateTo == DateTruncate.Hour)
                return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0);
            else if (TruncateTo == DateTruncate.Minute)
                return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);
            else 
                return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            
        }
        public enum DateTruncate
        {
            Year,
            Month,
            Day,
            Hour,
            Minute,
            Second
        }
