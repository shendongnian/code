    class Program
        {
    
            public static DateTime AddWorkingDays(DateTime specificDate,
                                          int workingDaysToAdd)
            {
                int completeWeeks = workingDaysToAdd / 5;
                DateTime date = specificDate.AddDays(completeWeeks * 7);
                workingDaysToAdd = workingDaysToAdd % 5;
                for (int i = 0; i < workingDaysToAdd; i++)
                {
                    date = date.AddDays(1);
                    while (!IsWeekDay(date))
                    {
                        date = date.AddDays(1);
                    }
                }
                return date;
            }
    
            private static bool IsWeekDay(DateTime date)
            {
                DayOfWeek day = date.DayOfWeek;
                return day != DayOfWeek.Saturday && day != DayOfWeek.Sunday;
            }
    
            public static DateTime MyAddWorkingDays(DateTime specificDate,
                                          int workingDaysToAdd)
            {
                int foundWorkingDays = 0;
                while (foundWorkingDays < workingDaysToAdd)
                {
                    specificDate = specificDate.AddDays(1);
                    if (specificDate.DayOfWeek != DayOfWeek.Sunday && specificDate.DayOfWeek != DayOfWeek.Saturday)
                        foundWorkingDays++;
    
                }
                return specificDate;
            }
    
    
            static void Main(string[] args)
            {
    
                DateTime specificDate = DateTime.Now;
    
                Stopwatch globalTimer = Stopwatch.StartNew();
                Console.WriteLine(AddWorkingDays(specificDate, 300));  // 100000 :)
                globalTimer.Stop();
                Console.WriteLine(globalTimer.ElapsedMilliseconds);
    
                globalTimer = Stopwatch.StartNew();
                Console.WriteLine(MyAddWorkingDays(specificDate, 300)); // 100000 :)
                globalTimer.Stop();
                Console.WriteLine(globalTimer.ElapsedMilliseconds);
    
    
    
                Console.ReadLine();
            }
        }
