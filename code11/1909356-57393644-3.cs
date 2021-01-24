    class Program
    {
        static void Main()
        {
            var combiner = new RangeCombiner();
            var from1 = new DateTime(2019, 08, 07, 10, 00, 00);
            var to1   = new DateTime(2019, 08, 07, 12, 00, 00);
            var from2 = new DateTime(2019, 08, 07, 10, 00, 00);
            var to2   = new DateTime(2019, 08, 07, 12, 00, 00);
            var from3 = new DateTime(2019, 08, 07, 11, 00, 00);
            var to3   = new DateTime(2019, 08, 07, 12, 00, 00);
            var from4 = new DateTime(2019, 08, 07, 11, 00, 00);
            var to4   = new DateTime(2019, 08, 07, 14, 00, 00);
            var from5 = new DateTime(2019, 08, 07, 14, 00, 00);
            var to5   = new DateTime(2019, 08, 07, 18, 00, 00);
            var from6 = new DateTime(2019, 08, 07, 15, 00, 00);
            var to6   = new DateTime(2019, 08, 07, 17, 00, 00);
            var from7 = new DateTime(2019, 08, 07, 18, 00, 00);
            var to7   = new DateTime(2019, 08, 07, 19, 00, 00);
            combiner.Include(from1.Ticks, to1.Ticks);
            combiner.Include(from2.Ticks, to2.Ticks);
            combiner.Include(from3.Ticks, to3.Ticks);
            combiner.Include(from4.Ticks, to4.Ticks);
            combiner.Include(from5.Ticks, to5.Ticks);
            combiner.Include(from6.Ticks, to6.Ticks);
            combiner.Include(from7.Ticks, to7.Ticks);
            Console.WriteLine("Total = " + TimeSpan.FromTicks(combiner.TotalIncludedRange()));
        }
    }
