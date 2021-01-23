    public static class Extensions
    {
        public static DateTime? toDate(this string dateTimeStr, string dateFmt)
        {
            // example: var dt="2011-03-21 13:26".toDate("yyyy-MM-dd HH:mm");
            const DateTimeStyles style=DateTimeStyles.AllowWhiteSpaces;
            DateTime? result=null;
            DateTime dt;
            if (DateTime.TryParseExact(dateTimeStr, dateFmt, 
                CultureInfo.InvariantCulture, style, out dt)) result=dt;
            return result;
        }
    }
