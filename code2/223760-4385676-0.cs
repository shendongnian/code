    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    
    namespace DateThing
    {
        class Program
        {
            static void Main(string[] args)
            {
                var holidays = new List<DateTime>()
                                   {
                                       new DateTime(2010, 12, 25),
                                       new DateTime(2010, 12, 26)
                                   };
    
    
                var futureDate = CalculateFutureDate(DateTime.Today, 20, holidays);
    
            }
    
            static DateTime CalculateFutureDate(DateTime fromDate, int numberofWorkDays, ICollection<DateTime> holidays)
            {
                var futureDate = fromDate;
    
                for (var i = 0; i < numberofWorkDays; i++ )
                {
                    if (futureDate.DayOfWeek == DayOfWeek.Saturday || futureDate.DayOfWeek == DayOfWeek.Sunday ||
                        (holidays != null && holidays.Contains(futureDate)))
                        futureDate = futureDate.AddDays(1); // Increase FutureDate by one because of condition
    
                    futureDate = futureDate.AddDays(1); // Add a working day
                }
                return futureDate;
            }
        }
    }
