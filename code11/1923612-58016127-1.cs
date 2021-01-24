    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Lists
    {
        class Program
        {
            static void Main(string[] args)
            {
                var list1 = new List<DateItem>
                {
                    new DateItem{Date = DateTime.UtcNow.AddDays(-2), Name = "The day before yesterday" },
                    new DateItem{Date = DateTime.UtcNow.AddDays(1), Name = "Tomorrow" }
                };
                var list2 = new List<DateItem>
                {
                    new DateItem{Date = DateTime.UtcNow.AddDays(2), Name = "The day after tomorrow" },
                    new DateItem{Date = DateTime.UtcNow.AddDays(-1), Name = "Yesterday" },
                    new DateItem{Date = DateTime.UtcNow, Name = "Today" }
            };
                var merged = list1.Union(list2).OrderByDescending(d => d.Date);
                foreach (var day in merged)
                {
                    Console.WriteLine(day.Name);
                }
            }
        }
        class DateItem
        {
            public DateTime Date { get; set; }
            public string Name { get; set; }
        }
    }
