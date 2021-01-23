    using System;
    using System.Collections.Generic;
    static class Program {
        // return dictionary tuple<year,month> -> number of days
        static Dictionary<Tuple<int, int>, int> GetNumberOfDays(DateTime start, DateTime end) {
            // assumes end > start
            Dictionary<Tuple<int, int>, int> ret = new Dictionary<Tuple<int, int>, int>();
            DateTime date = end;
            while (date > start) {
                if (date.Year == start.Year && date.Month == start.Month) {
                    ret.Add(
                        Tuple.Create<int, int>(date.Year, date.Month),
                        (date - start).Days + 1);
                    break;
                } else {
                    ret.Add(
                        Tuple.Create<int, int>(date.Year, date.Month),
                        date.Day);
                    date = new DateTime(date.Year, date.Month, 1).AddDays(-1);
                }
            }
            return ret;
        }
        static void Main(params string[] args) {
            var days = GetNumberOfDays(new DateTime(2011, 3, 1), new DateTime(2011, 4, 1));
            foreach (var m in days.Keys) {
                Console.WriteLine("{0}/{1} : {2} days", m.Item1, m.Item2, days[m]);
            }
        }
    }
