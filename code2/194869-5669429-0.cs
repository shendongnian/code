    class RollingOverWeekFileAppender : RollingFileAppender
    {
        private DateTime nextWeekendDate;
        public RollingOverWeekFileAppender()
        {
            CalcNextWeekend(DateTime.Now);
        }
        private void CalcNextWeekend(DateTime time)
        { 
            // Calc next sunday
            time = time.AddMilliseconds((double)-time.Millisecond);
            time = time.AddSeconds((double)-time.Second);
            time = time.AddMinutes((double)-time.Minute);
            time = time.AddHours((double)-time.Hour);
            nextWeekendDate = time.AddDays((double)(7 - (int)time.DayOfWeek));
        }
        protected override void AdjustFileBeforeAppend()
        {
            DateTime now = DateTime.Now;
            if (now >= nextWeekendDate)
            {
                CalcNextWeekend(now);
                // As you included the day and month AdjustFileBeforeAppend takes care of creating 
                // new file with the new name
                base.AdjustFileBeforeAppend();
            }
        }
    }
