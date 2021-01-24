        class WeekData
        {
            public DateTime WeekStartDate { get; set; }
            public DateTime WeekEndDate { get; set; }
            public int WeekStartDay //Gets Day in the year for the Week Start Date
            {
                get { return WeekStartDate.DayOfYear; }
            }
            public int WeekEndDay //Gets Day in the year for the Week End Date
            {
                get { return WeekEndDate.DayOfYear; }
            }
        }
Dummy WeeksInTheYear data
            List<WeekData> weeks = new List<WeekData>
            {
                new WeekData{WeekStartDate = new DateTime(2019,10,6), WeekEndDate = new DateTime(2019,10,12)},
                new WeekData{WeekStartDate = new DateTime(2019,10,13), WeekEndDate = new DateTime(2019,10,19)},
                new WeekData{WeekStartDate = new DateTime(2019,10,20), WeekEndDate = new DateTime(2019,10,26)},
                new WeekData{WeekStartDate = new DateTime(2019,10,27), WeekEndDate = new DateTime(2019,11,2)}
            };
Dummy Dates from the XML feed
List<DateTime> xmlDates = new List<DateTime> { new DateTime(2019, 11, 1), new DateTime(2019, 10, 12), new DateTime(2019, 10, 31) };
Filtering 
            var weeksINeed = new List<WeekData>();
            foreach (var date in xmlDates)
            {
                var weekINeed = weeks.Where(x => x.WeekStartDay <= date.DayOfYear && x.WeekEndDay >= date.DayOfYear)
                    .FirstOrDefault();
                if (!weeksINeed.Any(x => x.WeekStartDay == weekINeed.WeekStartDay))
                {
                    weeksINeed.Add(weekINeed);
                }
            }
Output - 
            foreach (var weekdata in weeksINeed.OrderBy(x=>x.WeekStartDay))
            {
                Console.WriteLine($"WeekStartDate - {weekdata.WeekStartDate} WeekEndDate - {weekdata.WeekEndDate}");
            }
[![test output][1]][1]
  [1]: https://i.stack.imgur.com/MMvsX.png
