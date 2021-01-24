    class Program
    {
      static void Main(string[] args)
      {
        var testString = string.Join(Environment.NewLine, Enumerable.Range(0, 1000000));
        var oldArray = testString.Split();
        Stopwatch stopwatch = Stopwatch.StartNew();
        var newString = string.Join(Environment.NewLine, oldArray);
        stopwatch.Stop();
        Console.WriteLine($"String length: {newString.Length}");
        Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
        stopwatch = Stopwatch.StartNew();
        newString = string.Join(Environment.NewLine, oldArray.Reverse().Skip(2).Reverse());
        stopwatch.Stop();
        Console.WriteLine($"String length: {newString.Length}");
        Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
      }
    }
