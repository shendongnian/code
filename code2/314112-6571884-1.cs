    public static IList<DatesBag> GetDateInfo(DateTime givenDate, int numberOfWeeks)
    {
        var result = new List<DatesBag>();
        for (int i = 0; i < numberOfWeeks; i++)
        {
            int firstWeekDay = Week.GetFirstDayOfWeek(givenDate).Day;
            DatesBag datesBag = new DatesBag
                                    {
                                        Week = (WeeksOfAMonth) ((firstWeekDay / 7) + ((firstWeekDay % 7 == 0) ? 0 : 1)),
                                        FirstDayOfWeek = Week.GetFirstDayOfWeek(givenDate),
                                        LastDayOfWeek = Week.GetLastDayOfWeek(givenDate)
                                        };
            result.Add(datesBag);
            givenDate = givenDate.AddDays(datesBag.WeekLength + 1);
         }
        return result;
    }
    public class DatesBag
    {
        public WeeksOfAMonth Week { get; set; }
        public DateTime FirstDayOfWeek { get; set; }
        public DateTime LastDayOfWeek { get; set; }
        public int WeekLength { get { return LastDayOfWeek.Day - FirstDayOfWeek.Day; } }
    }
    public static class Week
    {
        public static DateTime GetFirstDayOfWeek(DateTime givenDate)
        {
            DateTime tmp = givenDate;
            while (tmp.AddDays(-1).Month == givenDate.Month && tmp.DayOfWeek > DayOfWeek.Monday)
            {
                tmp = tmp.AddDays(-1);
            }
            return tmp;
        }
        public static DateTime GetLastDayOfWeek(DateTime givenDate)
        {
            DateTime tmp = givenDate;
            while (tmp.AddDays(1).Month == givenDate.Month && tmp.DayOfWeek != DayOfWeek.Sunday)
            {
                tmp = tmp.AddDays(1);
            }
            return tmp;
        }
    }
