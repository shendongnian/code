    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var weekStart = DateTime.Now;
                DateTime nextWeek;
    
                for (int i = 0; i < 10; i++)
                {
                    var weekEnd = weekStart.AddDays(6);
                    if (weekEnd.Month > weekStart.Month)
                    {
                        weekEnd = new DateTime(weekStart.Year, weekStart.Month + 1, 1).AddDays(-1);
                        nextWeek = weekEnd.AddDays(1);
                    }
                    else
                    {
                        nextWeek = weekStart.AddDays(7);
                    }
    
                    Console.WriteLine("Week {0}: F: {1} L: {2}", (weekStart.Day / 7) + 1, weekStart.ToShortDateString(), weekEnd.ToShortDateString());
    
                    weekStart = nextWeek;
                }
    
                Console.ReadKey();
            }
    
        }
    }
