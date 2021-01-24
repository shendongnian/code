    class Program
    {
        static void Main(string[] args)
        {
            var prices = new int[]{10, 21, 30, 90, 100, 150, 400}.ToList();
            var finalPriceList =
                Enumerable
                .Range(0, 10)
                .Select(i => prices.Min() + 10 * i)
                .TakeWhile(i => i < Math.Min(100, prices.Max()))
                .Concat(
                    Enumerable
                    .Range(1, 1000)
                    .Select(i => 100 * i)
                    .TakeWhile(i => i <= prices.Max())
                ).ToList();
            Console.WriteLine(string.Join(", ", finalPriceList));
        }
    }
