    IEnumerable<string> segments =
      from x in new List<string> { "one", "two" } select x;
    
    Console.WriteLine(segments.Count());  // works
    
    dynamic dSegments = segments;
    
    // Console.WriteLine(dSegments.Count());  // fails
    
    Console.WriteLine(Enumerable.Count(dSegments));  // works
