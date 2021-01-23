        public static bool InBetweenDaysInclusive(DateTime date, DayOfWeek start, DayOfWeek end)
        {
            DayOfWeek curDay = date.DayOfWeek;
            if (start <= end)
            {
                return (start <= curDay && curDay <= end);
            }
            else
            {
                return (start <= curDay || curDay <= end);
            }
        }
