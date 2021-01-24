    static void Main(string[] args)
    {
        var rand = new Random();
        Enumerable
            .Range(1, 7)
            .Aggregate(new List<int>(), (x, y) =>
            {
                var num = rand.Next(1, 51);
                while (x.Contains(num))
                {
                    num = rand.Next(1, 51);
                }
                x.Add(num);
                return x;
            })
            .ForEach(x => Console.Write($"{x} "));
    }
