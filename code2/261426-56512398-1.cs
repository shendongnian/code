    var source = "abbacdbbcac".ToCharArray();
    var indexes = Enumerable.Range(0, source.Length);
    var result = source.LocalMaxima(5);
    Console.WriteLine($"Source:  {String.Join(", ", source)}");
    Console.WriteLine($"Indexes: {String.Join("  ", indexes)}");
    Console.WriteLine($"Result:  {String.Join(", ", result)}");
