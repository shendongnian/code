csharp
        public struct Period
        {
            public DateTime PeriodStartDate { get; set; }
            public DateTime PeriodEndDate { get; set; }
            public Period(DateTime periodStartDate, DateTime periodEndDate)
            {
                this.PeriodStartDate = periodStartDate;
                this.PeriodEndDate = periodEndDate;
            }
        }
You can calculate how many periods within the giving interval and add days based on this periods. Here is the basic algorithm:
csharp
            DateTime startDate = DateTime.Parse("01/01/2019");
            DateTime endDate = DateTime.Parse("31/12/2019");
            int dayInterval = 90;
            var dateDiff = (endDate - startDate).TotalDays;
            int dateRatio = (int)dateDiff / dayInterval;
            var listDates = new List<Period>();
            var lastDate = startDate;
            for (int i = 0; i < dateRatio; i++)
            {
                var offsetDay = lastDate.AddDays(dayInterval);
                listDates.Add(new Period(lastDate, offsetDay));
                lastDate = offsetDay.AddDays(1);
            }
Also you can add some validation on `dateInterval` variable which can only be 180, 90, 45, 15, 7 and 1. Finally, algorithm can be shortened but i created variables separately for clear answer.
