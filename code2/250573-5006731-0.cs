        public static TimeSpan BusinessTimeDelta(DateTime start, DateTime stop)
        {
            if (start == stop)
                return TimeSpan.Zero;
            if (start > stop)
            {
                DateTime temp = start;
                start = stop;
                stop = temp;
            }
            // First we are going to truncate these DateTimes so that they are within the business day.
            // How much time from the beginning til the end of the day?
            DateTime startStartOfBusiness = new DateTime(start.Year, start.Month, start.Day, 9, 0, 0);
            DateTime startCloseOfBusiness = new DateTime(start.Year, start.Month, start.Day, 17, 0, 0);
            if (start < startStartOfBusiness) start = startStartOfBusiness;
            if (start > startCloseOfBusiness) start = startCloseOfBusiness;
            TimeSpan firstDayTime = startCloseOfBusiness - start;
            if (start.DayOfWeek == DayOfWeek.Saturday || start.DayOfWeek == DayOfWeek.Sunday)
                firstDayTime = TimeSpan.Zero;
            // How much time from the start of the last day til the end?
            DateTime stopStartOfBusiness = new DateTime(stop.Year, stop.Month, stop.Day, 9, 0, 0);
            DateTime stopCloseOfBusiness = new DateTime(stop.Year, stop.Month, stop.Day, 17, 0, 0);
            if (stop < stopStartOfBusiness) stop = stopStartOfBusiness;
            if (stop > stopCloseOfBusiness) stop = stopCloseOfBusiness;
            TimeSpan lastDayTime = stop - stopStartOfBusiness;
            if (stop.DayOfWeek == DayOfWeek.Saturday || stop.DayOfWeek == DayOfWeek.Sunday)
                lastDayTime = TimeSpan.Zero;
            // At this point all dates are snipped to within business hours.
            if (start.Date == stop.Date)
            {
                return stop - start;
            }
            // At this point we know they occur on different dates, so we can use
            // the offset from SOB and COB.
            TimeSpan timeInBetween = TimeSpan.Zero;
            TimeSpan hoursInAWorkday = (startCloseOfBusiness - startStartOfBusiness);
            // I tried cool math stuff instead of a for-loop, but that leaves no clean way to count holidays.
            for (DateTime itr = startStartOfBusiness.AddDays(1); itr < stopStartOfBusiness; itr = itr.AddDays(1))
            {
                // Holiday? (commented so I can test this)
                //if( isHoliday(itr) )
                //  continue;
                // Weekend?
                if (itr.DayOfWeek == DayOfWeek.Sunday || itr.DayOfWeek == DayOfWeek.Saturday)
                    continue;
                // Otherwise, it's a workday!
                timeInBetween += hoursInAWorkday;
            }
            return firstDayTime + lastDayTime + timeInBetween;
        }
