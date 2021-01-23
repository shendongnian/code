    namespace log4net.Appender
    {
        class RollingOverWeekFileAppender : RollingFileAppender
        {
            public RollingOverWeekFileAppender()
            {
                IDateTime dt = new SundayDateTime();
                DateTimeStrategy = dt;
            }
    
            class SundayDateTime : IDateTime
            {
                public DateTime Now
                {
                    get { return CalcThisSunday(DateTime.Now); }
                }
    
                private DateTime CalcThisSunday(DateTime time)
                {
                    // Calc this sunday
                    time = time.AddMilliseconds((double)-time.Millisecond);
                    time = time.AddSeconds((double)-time.Second);
                    time = time.AddMinutes((double)-time.Minute);
                    time = time.AddHours((double)-time.Hour);
                    return time.AddDays((double)(-(int)time.DayOfWeek));
                }
            }
        }
    }
