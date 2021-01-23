    using System;
    using System.Collections.Generic;
    using System.Linq;
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
    
    
                var workDays = GetNumberOfWorkDays(DateTime.Today, new DateTime(2011, 1, 1), holidays);
            }
    
            static int GetNumberOfWorkDays(DateTime fromDate, DateTime toDate, ICollection<DateTime> holidays)
            {
                var days = 0;
                for (var i = fromDate; i < toDate; )
                {
                    if (i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday && 
                        (holidays != null && !holidays.Contains(i)))
                        days++;
    
                    i = i.AddDays(1);
                }
                return days;
            }
        }
    
    
    }
