        public List<DateTime> AllDatesInAMonth(int month, int year)
        {
            var firstOftargetMonth = new DateTime(year, month, 1);
            var firstOfNextMonth = firstOftargetMonth.AddMonths(1);
            var allDates = new List<DateTime>();
            for (DateTime date = firstOftargetMonth; date < firstOfNextMonth; date = date.AddDays(1) )
            {
                allDates.Add(date);
            }
            return allDates;
        }
