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
                var d1 = new DateTime(1990, 1, 2);
                var d2 = new DateTime(2009, 5, 9);
                int days = d2.Day - d1.Day;
                int months = d2.Month - d1.Month;
                int years = d2.Year - d1.Year;
                if (days < 0)
                {
                    days += 30;
                    months -= 1;
                }
                if (months < 0)
                {
                    months += 12;
                    years -= 1;
                }
           
                Console.WriteLine("{0} Days, {1} Months, {2} Years", days, months, years);
                Console.ReadLine();
            }
        }
    }
