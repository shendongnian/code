       public enum EventTimings
        {
            Every12Hours,  // 12pm and midnight
            Weekly // sunday at midnight
        }
    
    
        public static DateTime CalculateEventTime(EventTimings eventTime, DateTime inputDate)
        {
            DateTime time = DateTime.Now;
            switch (eventTime)
            {
                case EventTimings.Every12Hours:
                    time = inputDate.Hour > 12 ? inputDate.AddDays(1).Date + new TimeSpan(0, 0, 0) : inputDate.Date + new TimeSpan(12, 0, 0);
                    return time;
                case EventTimings.Weekly:
                    int dayoftheweek = (int) inputDate.DayOfWeek;
                    time = inputDate.AddDays(8 - dayoftheweek).Date + new TimeSpan(0, 0, 0);
                    return time;
    // other cases
            }
    
        }
