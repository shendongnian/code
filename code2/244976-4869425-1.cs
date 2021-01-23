    static void Main(string[] args)
    {
        var groups = new[]
                        {
                            new Tuple<string, int>("Group1", 15),
                            new Tuple<string, int>("Group2", 5),
                            new Tuple<string, int>("Group3", 17),
                        };
        foreach (var sum in groups
            .Combinations()
            .Select(x => 
                string.Join(" + ", x.Select(tuple => tuple.Item1)) + 
                " = " + 
                x.Sum(tuple => tuple.Item2)))
        {
            Console.WriteLine(sum);
        }
        Console.ReadLine();
    }
