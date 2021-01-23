        public static DateTime EndOfWeek(DateTime dateTime)
        {
            DateTime start = StartOfWeek(dateTime);
            return start.AddDays(6);
        }
        public static DateTime StartOfWeek(DateTime dateTime)
        {
            int days = dateTime.DayOfWeek - DayOfWeek.Monday; 
            
            if (days < 0) 
                days += 7;
            return dateTime.AddDays(-1 * days).Date;
        }
