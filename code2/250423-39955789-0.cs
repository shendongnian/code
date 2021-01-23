    public static class DateTimeExtensions 
        {
            /// <summary>
            /// get the datetime of the start of the week
            /// </summary>
            /// <param name="dt"></param>
            /// <param name="startOfWeek"></param>
            /// <returns></returns>
            /// <example>
            /// DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            /// DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
            /// </example>
            /// <remarks>http://stackoverflow.com/a/38064/428061</remarks>
            public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
            {
                var diff = dt.DayOfWeek - startOfWeek;
                if (diff < 0)
                    diff += 7;
    
                return dt.AddDays(-1 * diff).Date;
            }
    
            /// <summary>
            /// get the datetime of the start of the month
            /// </summary>
            /// <param name="dt"></param>
            /// <returns></returns>
            /// <remarks>http://stackoverflow.com/a/5002582/428061</remarks>
            public static DateTime StartOfMonth(this DateTime dt)
            {
                var now = DateTime.Now;
                return new DateTime(now.Year, now.Month, 1);
            }
    
            /// <summary>
            /// get datetime of the start of the year
            /// </summary>
            /// <param name="dt"></param>
            /// <returns></returns>
            public static DateTime StartOfYear(this DateTime dt)
            {
                var now = DateTime.Now;
                return new DateTime(now.Year, 1, 1);
            }
        }
