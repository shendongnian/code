        private List<DateTime> GetUnincludedMonths(DateTime startDate, DateTime endDate,
                                                   IEnumerable<DateTime> dates)
        {
            var allMonths = new HashSet<Tuple<int, int>>(); //month, year
            DateTime date = startDate;
            while (date <= endDate)
            {
                allMonths.Add(Tuple.Create(date.Month, date.Year));
                date = date.AddMonths(1);
            }
            allMonths.ExceptWith(dates.Select(dt => Tuple.Create(dt.Month, dt.Year)));
            return allMonths.Select(t => new DateTime(t.Item2, t.Item1, 1)).ToList();
        }
