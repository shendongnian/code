        public void DateThing()
        {
            List<DateTime> dateList = new List<DateTime>();
            DateTime start = DateTime.Parse("1/1/2010");
            
            for (int i = 0; i < 1000; i++)
            {
                dateList.Add(start.AddDays(i));
            }
            var dateYouWant = GetDayOfWeekForGivenYear(DayOfWeek.Friday, 37, 2011, dateList);
        }
        private DateTime GetDayOfWeekForGivenYear(DayOfWeek dayOfWeek, int weekNum, int year, List<DateTime> dateList)
        {
            var days = dateList.Where(w => w.Year == year && w.DayOfWeek == dayOfWeek);
            var day = days.FirstOrDefault(w => w.DayOfYear >= (weekNum - 1) * 7);
            return day.DayOfYear < 7 ? day.AddDays(-7) : day;
        }
