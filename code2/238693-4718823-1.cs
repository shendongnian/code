        public static IEnumerable<DateTime> DaysUpTo(this DateTime startDate, DateTime endDate)
        {
            DateTime currentDate = startDate;
            while (currentDate <= endDate)
            {
                yield return currentDate;
                currentDate = currentDate.AddDays(1);
            }
        }
