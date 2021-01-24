        public class Timesheet
        {
            private static List<Timesheet> timeSheets { get; set; }
            private static List<KeyValuePair<DateTime, List<Timesheet>>> weeks { get; set; }
            private int index { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
            public int Effort { get; set; }
            public DateTime Day { get; set; }
            public void AddTimeSheets(List<Timesheet> timesheets)
            {
                Timesheet.timeSheets = timesheets;
                weeks = timesheets
                    .OrderBy(x => x.Day)
                    .GroupBy(x => x.Day.Date.AddDays(-1 * (int)x.Day.DayOfWeek)).Select(x => new KeyValuePair<DateTime, List<Timesheet>>(x.Key, new List<Timesheet>(x.ToList()))).ToList();
                index = 0;
            }
            public KeyValuePair<object, List<KeyValuePair<string, int[]>>> Current()
            {
                if (weeks.Count() == 0)
                {
                    return new KeyValuePair<object, List<KeyValuePair<string, int[]>>>();
                }
                else
                {
                    return new KeyValuePair<object, List<KeyValuePair<string, int[]>>>(weeks[index].Key, GetWeek(weeks[index].Value));
                }
            }
            public KeyValuePair<object, List<KeyValuePair<string, int[]>>> Next()
            {
                if (index >= weeks.Count() - 1)
                {
                    return new KeyValuePair<object, List<KeyValuePair<string, int[]>>>();
                }
                else
                {
                    index++;
                    return new KeyValuePair<object, List<KeyValuePair<string, int[]>>>(weeks[index].Key, GetWeek(weeks[index].Value));
                }
            }
            public KeyValuePair<object, List<KeyValuePair<string, int[]>>> Previous()
            {
                if (index <= 0)
                {
                    return new KeyValuePair<object, List<KeyValuePair<string, int[]>>>();
                }
                else
                {
                    index--;
                    return new KeyValuePair<object, List<KeyValuePair<string, int[]>>>(weeks[index].Key, GetWeek(weeks[index].Value));
                }
            }
            public List<KeyValuePair<string, int[]>> GetWeek(List<Timesheet> week)
            {
                List<KeyValuePair<string, int[]>> results = new List<KeyValuePair<string, int[]>>();
                var summary = week
                    .GroupBy(x => new { name = x.Name, day = x.Day })
                    .Select(x => new Timesheet() { Day = x.Key.day, Name = x.Key.name, Id = x.First().Id, Effort = x.Sum(y => y.Effort) })
                    .GroupBy(x => x.Name)
                    .ToList();
                foreach (var name in summary)
                {
                    int[] effort = new int[7];
                    foreach (var day in name)
                    {
                        effort[(int)day.Day.DayOfWeek] = day.Effort;
                    }
                    results.Add(new KeyValuePair<string, int[]>(name.Key, effort));
                }
                return results;
            }
        }
