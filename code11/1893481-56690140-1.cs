    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication116
    {
        class Program
        {
            static void Main(string[] args)
            {
                var jobs = new List<Job>()
                {
                    new Job { Level = 1, Date = new DateTime(2019, 1, 1), Quantity = 111 },
                    new Job { Level = 1, Date = new DateTime(2019, 1, 20), Quantity = 222 },
                    new Job { Level = 2, Date = new DateTime(2019, 2, 1), Quantity = 333 },
                    new Job { Level = 2, Date = new DateTime(2019, 2, 20), Quantity = 444 }
                };
                var solutions = new List<Solution>()
                {
                    new Solution { Level = 1, Date = new DateTime(2019, 2, 1), Quantity = 555 },
                    new Solution { Level = 2, Date = new DateTime(2019, 2, 20), Quantity = 666 },
                    new Solution { Level = 1, Date = new DateTime(2019, 1, 1), Quantity = 777 },
                    new Solution { Level = 2, Date = new DateTime(2019, 1, 20), Quantity = 888 }
                };
                List<LevelDateQuantity> concat = jobs.Select(x => new LevelDateQuantity() { Date = x.Date, Level = x.Level, Quantity = x.Quantity})
                    .Concat( solutions.Select(x => new LevelDateQuantity() { Date = x.Date, Level = x.Level, Quantity = x.Quantity})).ToList();
                List<LevelDateQuantity> results = concat.OrderBy(x => x.Level).ThenBy(x => x.Date)
                    .GroupBy(x => new { level = x.Level, date = new DateTime(x.Date.Year, x.Date.Month,1)})
                    .Select(x => new LevelDateQuantity() { Level = x.Key.level, Date = x.Key.date, Quantity = x.Sum(y => y.Quantity)})
                    .ToList();
            }
     
        }
        public class LevelDateQuantity
        {
            public int Level { get; set; }
            public DateTime Date { get; set; }
            public int Quantity { get; set; }
        }
        public class Job : LevelDateQuantity
        {
            public int Level { get; set; }
            public DateTime Date { get; set; }
            public int Quantity { get; set; }
        }
        public class Solution : LevelDateQuantity
        {
            public int Level { get; set; }
            public DateTime Date { get; set; }
            public int Quantity { get; set; }
        }
    }
