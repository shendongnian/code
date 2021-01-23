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
            DateTime startFloor = StartOfBusiness(start);
            DateTime startCeil = CloseOfBusiness(start);
            if (start < startFloor) start = startFloor;
            if (start > startCeil) start = startCeil;
            TimeSpan firstDayTime = startCeil - start;
            bool workday = true; // Saves doublechecking later
            if (!IsWorkday(start))
            {
                workday = false;
                firstDayTime = TimeSpan.Zero;
            }
            // How much time from the start of the last day til the end?
            DateTime stopFloor = StartOfBusiness(stop);
            DateTime stopCeil = CloseOfBusiness(stop);
            if (stop < stopFloor) stop = stopFloor;
            if (stop > stopCeil) stop = stopCeil;
            TimeSpan lastDayTime = stop - stopFloor;
            if (!IsWorkday(stop))
                lastDayTime = TimeSpan.Zero;
            // At this point all dates are snipped to within business hours.
            if (start.Date == stop.Date)
            {
                if (!workday) // Precomputed value from earlier
                    return TimeSpan.Zero;
                return stop - start;
            }
            // At this point we know they occur on different dates, so we can use
            // the offset from SOB and COB.
            TimeSpan timeInBetween = TimeSpan.Zero;
            TimeSpan hoursInAWorkday = (startCeil - startFloor);
            // I tried cool math stuff instead of a for-loop, but that leaves no clean way to count holidays.
            for (DateTime itr = startFloor.AddDays(1); itr < stopFloor; itr = itr.AddDays(1))
            {
                if (!IsWorkday(itr))
                    continue;
                // Otherwise, it's a workday!
                timeInBetween += hoursInAWorkday;
            }
            return firstDayTime + lastDayTime + timeInBetween;
        }
        public static bool IsWorkday(DateTime date)
        {
            // Weekend
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                return false;
            // Could add holiday logic here.
            return true;
        }
        public static DateTime StartOfBusiness(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 9, 0, 0);
        }
        public static DateTime CloseOfBusiness(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 17, 0, 0);
        }
