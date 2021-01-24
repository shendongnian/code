    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication132
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Dates> dates = Dates.GetDates();
                var results = dates.GroupBy(x => new DateTime(x.Time.Year, x.Time.Month, x.Time.Day, x.Time.Hour, 15 * (x.Time.Minute / 15), 0).AddMinutes(15))
                    .Select(x => x.OrderBy(y => x.Key.Subtract(y.Time)).First())
                    .ToList();
            }
        }
        public class Dates
        {
            public int ID { get;set;}
            public int Value { get;set;}
            public DateTime Time { get;set;}
            public static List<Dates> GetDates()
            {
                string input =
                    "| 1           | 1          | 2019-03-07 20:05:35 |\n" +
                    "| 2           | 2          | 2019-03-07 20:06:09 |\n" +
                    "| 5           | 5          | 2019-03-07 20:11:27 |\n" +
                    "| 7           | 1          | 2019-03-07 20:13:30 |\n" +
                    "| 8           | 0          | 2019-03-07 20:13:41 |\n" +
                    "| 7           | 1          | 2019-03-07 20:17:00 |\n" +
                    "| 8           | 0          | 2019-03-07 20:22:20 |\n" +
                    "| 7           | 1          | 2019-03-07 20:23:05 |\n" +
                    "| 8           | 0          | 2019-03-07 20:27:35 |\n" +
                    "| 7           | 1          | 2019-03-07 20:27:37 |\n" +
                    "| 8           | 0          | 2019-03-07 20:28:01 |\n" +
                    "| 7           | 1          | 2019-03-07 20:37:19 |\n" +
                    "| 8           | 0          | 2019-03-07 20:37:27 |\n" +
                    "| 7           | 1          | 2019-03-07 20:37:54 |\n" +
                    "| 8           | 0          | 2019-03-07 20:40:11 |\n" +
                    "| 7           | 1          | 2019-03-07 20:44:00 |\n" +
                    "| 8           | 0          | 2019-03-07 20:45:00 |\n" +
                    "| 7           | 1          | 2019-03-07 20:47:41 |\n" +
                    "| 7           | 1          | 2019-03-07 20:48:43 |\n" +
                    "| 7           | 1          | 2019-03-07 20:48:51 |\n" +
                    "| 8           | 0          | 2019-03-07 20:51:11 |\n" +
                    "| 8           | 0          | 2019-03-07 20:54:46 |\n" +
                    "| 8           | 0          | 2019-03-07 20:55:36";
                List<Dates> dates = new List<Dates>();
                string line = "";
                StringReader reader = new StringReader(input);
                while ((line = reader.ReadLine()) != null)
                {
                    string[] lineArray = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    Dates newDate = new Dates()
                    {
                        ID = int.Parse(lineArray[0]),
                        Value = int.Parse(lineArray[1]),
                        Time = DateTime.Parse(lineArray[2])
                    };
                    dates.Add(newDate);
                }
                return dates;
            }
        }
    }
