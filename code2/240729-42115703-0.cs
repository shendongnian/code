        public static DateTime? GetNextTransition(DateTime asOfTime, TimeZoneInfo timeZone)
        {
            TimeZoneInfo.AdjustmentRule[] adjustments = timeZone.GetAdjustmentRules();
            if (adjustments.Length == 0)
            {
                // if no adjustment then no transition date exists
                return null;
            }
            int year = asOfTime.Year;
            TimeZoneInfo.AdjustmentRule adjustment = null;
            foreach (TimeZoneInfo.AdjustmentRule adj in adjustments)
            {
                // Determine if this adjustment rule covers year desired
                if (adj.DateStart.Year <= year && adj.DateEnd.Year >= year)
                {
                    adjustment = adj;
                    break;
                }
            }
            if (adjustment == null)
            {
                // no adjustment found so no transition date exists in the range
                return null;
            }
            DateTime dtAdjustmentStart = GetAdjustmentDate(adjustment.DaylightTransitionStart, year);
            DateTime dtAdjustmentEnd = GetAdjustmentDate(adjustment.DaylightTransitionEnd, year);
            if (dtAdjustmentStart >= asOfTime)
            {
                // if adjusment start date is greater than asOfTime date then this should be the next transition date
                return dtAdjustmentStart;
            }
            else if (dtAdjustmentEnd >= asOfTime)
            {
                // otherwise adjustment end date should be the next transition date
                return dtAdjustmentEnd;
            }
            else
            {
                // then it should be the next year's DaylightTransitionStart
                year++;
                foreach (TimeZoneInfo.AdjustmentRule adj in adjustments)
                {
                    // Determine if this adjustment rule covers year desired
                    if (adj.DateStart.Year <= year && adj.DateEnd.Year >= year)
                    {
                        adjustment = adj;
                        break;
                    }
                }
                dtAdjustmentStart = GetAdjustmentDate(adjustment.DaylightTransitionStart, year);
                return dtAdjustmentStart;
            }
        }
        public static DateTime GetAdjustmentDate(TimeZoneInfo.TransitionTime transitionTime, int year)
        {
            if (transitionTime.IsFixedDateRule)
            {
                return new DateTime(year, transitionTime.Month, transitionTime.Day);
            }
            else
            {
                // For non-fixed date rules, get local calendar
                Calendar cal = CultureInfo.CurrentCulture.Calendar;
                // Get first day of week for transition
                // For example, the 3rd week starts no earlier than the 15th of the month
                int startOfWeek = transitionTime.Week * 7 - 6;
                // What day of the week does the month start on?
                int firstDayOfWeek = (int)cal.GetDayOfWeek(new DateTime(year, transitionTime.Month, 1));
                // Determine how much start date has to be adjusted
                int transitionDay;
                int changeDayOfWeek = (int)transitionTime.DayOfWeek;
                if (firstDayOfWeek <= changeDayOfWeek)
                    transitionDay = startOfWeek + (changeDayOfWeek - firstDayOfWeek);
                else
                    transitionDay = startOfWeek + (7 - firstDayOfWeek + changeDayOfWeek);
                // Adjust for months with no fifth week
                if (transitionDay > cal.GetDaysInMonth(year, transitionTime.Month))
                    transitionDay -= 7;
                return new DateTime(year, transitionTime.Month, transitionDay, transitionTime.TimeOfDay.Hour, transitionTime.TimeOfDay.Minute, transitionTime.TimeOfDay.Second);
            }
        }
