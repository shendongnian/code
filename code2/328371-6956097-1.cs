    [Test]
    public void TestRandom()
    {
        IEnumerable<int> source = Enumerable.Range(1, 10);
        Dictionary<int, int> result = source.ToDictionary(element => element, element => 0);
        result[0] = 0;
        const int Limit = 1000000;
        for (int i = 0; i < Limit; i++)
        {
            result[source.RandomOrDefault()]++;
        }
        foreach (var pair in result)
        {
            Console.WriteLine("{0}: {1:F2}%", pair.Key, pair.Value * 100f / Limit);
        }
        Console.WriteLine(Enumerable.Empty<int>().RandomOrDefault());
    }
