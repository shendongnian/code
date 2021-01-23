    using System;
    
    class Program
    {
        static void Main()
        {
            ShowDifference(new DateTime(1990, 1, 2),
                           new DateTime(2009, 5, 9));
        }
        
        static void ShowDifference(DateTime start,
                                   DateTime end)
        {
            if (start > end)
            {
                throw new ArgumentException();
            }
            // See comment at the end
            int years = end.Year - start.Year - 2;
            while (start.AddYears(years) <= end)
            {
                years++;
            }
            years--;
            Console.WriteLine("{0} years", years);
            start = start.AddYears(years);
            int months = 0;
            while (start.AddMonths(months) <= end)
            {
                months++;
            }
            months--;
            Console.WriteLine("{0} months", months);
            start = start.AddMonths(months);
            int days = 0;
            while (start.AddDays(days) <= end)
            {
                days++;
            }
            days--;
            Console.WriteLine("{0} days", days);
        }
    }
