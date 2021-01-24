    public static void Main()
    {
        var random = new Random();
        var sourceDates = Enumerable.Range(1, 100)
            .Select(i => DateTime.UtcNow.Add(TimeSpan.FromDays(random.Next(-1000, 1000))))
            .ToList();
        var values = sourceDates.Select(date => date.ToBinary()).ToArray();
        var asBytes = SerializeBlockCopy(values, 0, values.Length);
        var filename = Path.GetTempFileName();
        WriteToFile(asBytes, filename);
        var bytesFromFile = ReadFromFile(filename);
        var back = DeserializeBlockCopy<long>(bytesFromFile);
        File.Delete(filename);
        var destinationValues = back.Select(value => DateTime.FromBinary(value)).ToList();
        var pairs = sourceDates.Zip(destinationValues, (s, d) => (s, d));
        foreach (var pair in pairs)
        {
            Console.WriteLine($"{pair.s} -> {pair.d}");
        }
        Console.WriteLine($"Both are equal: {sourceDates.SequenceEqual(destinationValues)}");
    }
    public static void WriteToFile(byte[] source, string filename)
    {
        using (var writer = new FileStream(filename, FileMode.Truncate, FileAccess.Write))
        {
            writer.Write(source, 0, source.Length);
        }
    }
    public static byte[] ReadFromFile(string filename)
    {
        return File.ReadAllBytes(filename);
    }
