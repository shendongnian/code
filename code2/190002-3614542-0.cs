    class Program
    {
        static void Main(string[] args)
        {
            DateTime startDate = new DateTime(2010, 09, 1);
            foreach(DateTime dt in EachMonth( new DateTime(2010, 09, 1), new DateTime(2011, 09, 1))){
                DateTime? result = GetDayByWeekOffset(DayOfWeek.Sunday, dt, 4);
               Console.WriteLine("Sunday:" + (result.HasValue?result.Value.ToString("MM-dd-yyyy"):"null"));
            }
            Console.ReadKey();
        }
        public static DateTime? GetDayByWeekOffset(DayOfWeek day, DateTime month, int weekOffSet)
        {
            //First day of month
            DateTime firstDayOfMonth = month.AddDays((-1 * month.Day) + 1);
            // 
            int daysOffSet;
            daysOffSet= ((int)day + 7 - (int)firstDayOfMonth.DayOfWeek) % 7;
            DateTime firstDay = month.AddDays(daysOffSet);
            // Add the number of weeks specified
            DateTime resultDate = firstDay.AddDays((weekOffSet - 1) * 7);
            if (resultDate.Month != firstDayOfMonth.Month){
                return null;
            }else{
                return resultDate;
            }
        }
        public static IEnumerable<DateTime> EachMonth(DateTime from, DateTime thru)
        {
            for (var month = from.Date; month.Date <= thru.Date; month = month.AddMonths(1))
                yield return month;
        }
    }
