    class Program
    {
        static void Main()
        {
            var target = new DateTime(2011, 10, 17, 13, 10, 0);
            IEnumerable<DateTime> choices = GetChoices();
            var closest = choices.OrderBy(c => Math.Abs(target.Subtract(c).TotalMinutes)).First();
            Console.WriteLine(closest);
        }
        private static IEnumerable<DateTime> GetChoices()
        {
            return new[]
                       {
                           new DateTime(2011, 10, 17, 4, 30, 0), 
                           new DateTime(2011, 10, 17, 12, 10, 0), 
                           new DateTime(2011, 10, 17, 15, 30, 0), 
                           new DateTime(2011, 10, 17, 22, 00, 0), 
                       };
        }
    }
