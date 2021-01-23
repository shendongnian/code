    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace DateTimeTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var dt1 = new DateTime(1990, 1, 2);
                var dt2 = new DateTime(2009, 5, 9);
                int days = dt2.Day - dt1.Day;
                int months = dt2.Month - dt1.Month;
                int years = dt2.Year - dt1.Year;
                if (months < 0)
                {
                    months += 12;
                    years -= 1;
                }
                if (days < 0)
                {
                    dt1.AddYears(years);
                    dt1.AddMonths(months);
                    days = dt2.Subtract(dt1).Days;
                    months -= 1;
                }
                Console.WriteLine("{0} Days, {1} Months, {2} Years", days, months, years);
            }
        }
    }
