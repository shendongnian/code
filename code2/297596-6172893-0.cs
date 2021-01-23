    class Program
    {
        class CoinToss
        {
            public int Value;
            public int RunCount;
        }
        static void Main(string[] args)
        {
            int[] values = new int[] { 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1 };
            var coinTosses = values.Select(v => new CoinToss() { Value = v, RunCount = 1 }).ToList();
            coinTosses.Aggregate(
                (previous, current) =>
                {
                    current.RunCount = current.Value == previous.Value
                        ? previous.RunCount + 1
                        : 1;
                    return current;
                });
            foreach (var coinToss in coinTosses)
            {
                Console.WriteLine("Value: {0}, Run Count: {1}", coinToss.Value, coinToss.RunCount);
            }
        }
    }
