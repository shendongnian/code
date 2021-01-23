    namespace log4net.Appender
    {
        class RollingOverWeekFileAppender : RollingFileAppender
        {
            private DateTime now;
            private DateTime thisSunday;
            public RollingOverWeekFileAppender()
            {
                now = DateTime.Now;
                CalcThisSunday(now);
                IDateTime dt = new CustomDateTime(thisSunday);
                DateTimeStrategy = dt;
            }
            private void CalcThisSunday(DateTime time)
            {
                // Calc this sunday
                time = time.AddMilliseconds((double)-time.Millisecond);
                time = time.AddSeconds((double)-time.Second);
                time = time.AddMinutes((double)-time.Minute);
                time = time.AddHours((double)-time.Hour);
                thisSunday = time.AddDays((double)(-(int)time.DayOfWeek));
            }
            class CustomDateTime : IDateTime
            {
                DateTime dt;
                public CustomDateTime(DateTime dt)
                {
                    this.dt = dt;
                }
                public DateTime Now
                {
                    get { return dt; }
                }
            }
        }
    }
