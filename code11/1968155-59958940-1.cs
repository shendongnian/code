    public static void Main()
    {
        // Create a list of sample items
        List<Item> items = new List<Item>
        {
            new Item {Value = 10, Date = DateTime.Parse("02/14/2020"), Interval = 33},
            new Item {Value = 23, Date = DateTime.Parse("01/10/2020"), Interval = 34},
            new Item {Value = 15, Date = DateTime.Parse("03/24/2020"), Interval = 10},
            new Item {Value = 69, Date = DateTime.Parse("06/20/2020"), Interval = 65},
            new Item {Value = 52, Date = DateTime.Parse("08/15/2020"), Interval = 63},
            new Item {Value = 34, Date = DateTime.Parse("11/20/2020"), Interval = 100},
            new Item {Value = 42, Date = DateTime.Parse("12/20/2020"), Interval = 97},
        };
        var results = new List<Result>();
        foreach (var item in items)
        {
            var interval = item.Interval / 10 * 10 + (item.Interval % 10 < 5 ? 0 : 5);
            // Try to find a result that this item can be added to
            var match = results.FirstOrDefault(r =>
                r.IntervalStart <= item.Interval &&
                r.IntervalStart + r.Interval >= item.Interval &&
                r.StartDate <= item.Date &&
                r.EndDate >= item.Date);
            // No existing result found, so create a new one for this item
            if (match == null)
            {
                var month = item.Date.Month / 4 * 3 + 1;
                var startDate = new DateTime(item.Date.Year, month, 1);
                var endDate = startDate.AddMonths(3).AddDays(-1);
                results.Add(new Result
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    IntervalStart = interval,
                    Value = item.Value
                });
            }
            else
            {
                match.Value += item.Value;
            }
        }
        results.ForEach(Console.WriteLine);
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
