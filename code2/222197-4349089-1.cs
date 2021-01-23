    IEnumerable<double> differences = Enumerable
        .Range(0, minus.Length)
        .Select(i => plus[i] - minus[i]);
    
    double current = differences.First();
    IEnumerable<string> analysis = differences
      .Skip(1)
      .Select(next =>
      {
        string result = DetermineCollisionInfo(current, next);
        current = next;
        return result;
      });
    
    foreach(string info in analysis)
    {
      Console.WriteLine(analysis);
    }
