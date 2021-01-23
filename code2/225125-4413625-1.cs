    public class so_4413380
    {
        private class DateGroup
        {
            public IList<DateTime> Dates { get; set; }
            public DateTime First
            {
                get { return Dates.OrderBy(d => d).FirstOrDefault(); }
            }
            public DateTime Last
            {
                get { return Dates.OrderBy(d => d).LastOrDefault(); }
            }
            public DateGroup()
            {
                Dates = new List<DateTime>();
            }
        }
        public void Execute()
        {
            var dateTimeFormat = CultureInfo.GetCultureInfo("en-US").DateTimeFormat;
            var dates = new[] { "11/15/2010", "12/1/10", "12/2/10", "12/3/10", "12/4/10", "12/9/10" };
            var realDates = dates.Select(s => DateTime.Parse(s, dateTimeFormat));
            var dateGroups = new List<DateGroup>();
            DateTime lastDate = DateTime.MinValue;
            foreach (var date in realDates.OrderBy(d => d))
            {
                if (date.Month == lastDate.Month && (date - lastDate).Days <= 1)
                {
                    var dateGroup = dateGroups.LastOrDefault();
                    dateGroup.Dates.Add(date);
                }
                else
                {
                    var dateGroup = new DateGroup();
                    dateGroups.Add(dateGroup);
                    dateGroup.Dates.Add(date);
                }
                lastDate = date;
            }
            foreach (var dateGroup in dateGroups)
            {
                if (dateGroup.Dates.Count == 1)
                {
                    Console.WriteLine(dateGroup.First.ToString(dateTimeFormat.ShortDatePattern, dateTimeFormat));
                }
                else
                {
                    int firstDay = dateGroup.First.Day;
                    int lastDay = dateGroup.Last.Day;
                    var dateString = dateTimeFormat.ShortDatePattern.Replace("d", firstDay + "-" + lastDay);
                    Console.WriteLine(dateGroup.First.ToString(dateString, dateTimeFormat));
                }
            }
            Console.ReadLine();
        }
    }
