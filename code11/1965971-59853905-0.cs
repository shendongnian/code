    public static void Main()
    {
        var random = new Random();
        var sourceDates = Enumerable.Range(1, 100)
            .Select(i => DateTime.UtcNow.Add(TimeSpan.FromDays(random.Next(-1000, 1000))))
            .ToList();
        var values = sourceDates.Select(date => date.ToBinary()).ToArray();
        var asBytes = SerializeBlockCopy<long>(values, 0, values.Length);
        var back = DeserializeBlockCopy<long>(asBytes);
        var destinationValues = back.Select(value => DateTime.FromBinary(value)).ToList();
        var pairs = sourceDates.Zip(destinationValues, (s, d) => (s, d));
        foreach (var pair in pairs)
        {
            Console.WriteLine($"{pair.s} -> {pair.d}");
        }
        // Returns true
        Console.WriteLine($"Both are equal: {sourceDates.SequenceEqual(destinationValues)}");
    }
