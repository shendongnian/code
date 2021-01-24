    class Program
    {
      static void Main(string[] args)
      {
        var array = Enumerable.Range(0, 1000000);
        Stopwatch stopwatch = Stopwatch.StartNew();
        var newArray = array.Reverse().Skip(2).Reverse();
        stopwatch.Stop();
        Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine($"Old array count: {array.Count()}");
        Console.WriteLine($"New array count: {newArray.Count()}");
      }
    }
