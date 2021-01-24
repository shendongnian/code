    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Globalization;
    namespace ConsoleApplication120
    {
        class Program
        {
            static void Main(string[] args)
            {
                for (int i = 1; i <= 12; i++)
                {
                    DateTime firstDayOfMonth = new DateTime(2019, i, 1);
                    DateTime firstMondayOfMonth = FirstMonday(2019, i);
                    Console.WriteLine("Month {0}, First Day of Month {1}, First Monday {2}", i,firstDayOfMonth.DayOfWeek.ToString(), firstMondayOfMonth);
                }
                Console.ReadLine();
            }
            static DateTime FirstMonday(int year, int month)
            {
                DateTime firstDayOfMonth = new DateTime(year, month, 1);
                DayOfWeek dayOfWeek = firstDayOfMonth.DayOfWeek;
                int addDays = (DayOfWeek.Monday - dayOfWeek + 7) % 7;
                return firstDayOfMonth.AddDays(addDays);
            }
     
        }
     
    }
