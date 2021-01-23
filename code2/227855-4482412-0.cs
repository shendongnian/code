    class Program
    {
        static void Main(string[] args)
        {
            int month = DateTime.Today.Month;
            int year = DateTime.Today.Year;
            
            int daysInMonthMinusFridayAndSaturday = 0;
            for (int i = 1; i <= DateTime.DaysInMonth(year,month); i++)
            {
                DateTime thisDay = new DateTime(year,month,i);
                if(thisDay.DayOfWeek != DayOfWeek.Friday && thisDay.DayOfWeek != DayOfWeek.Saturday)
                {
                    daysInMonthMinusFridayAndSaturday += 1;
                }
            }
            Console.WriteLine(daysInMonthMinusFridayAndSaturday);
            Console.ReadLine();
        }
    }
