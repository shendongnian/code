    class Program
    {
        static void Main()
        {
            var list = new[]
            {
                new { Date = new DateTime(2009, 1, 1), Value = 120 },
                new { Date = new DateTime(2009, 4, 1), Value = 121 },
                new { Date = new DateTime(2009, 12, 30), Value = 520 },
                new { Date = new DateTime(2010, 1, 1), Value = 100 },
                new { Date = new DateTime(2009, 4, 1), Value = 101 },
                new { Date = new DateTime(2010, 12, 31), Value = 540 },
            };
            var result = list
                .GroupBy(x => x.Date.Year)
                .Select(g => new { Date = g.Key, MaxValue = g.Max(x => x.Value) });
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
