    var windows = first.Window(second.Count);
    var result = windows
                    .Select((subset, index) => new { subset, index = (int?)index })
                    .Where(z => Enumerable.SequenceEqual(second, z.subset))
                    .Select(z => z.index)
                    .FirstOrDefault();
    
    Console.WriteLine(result);
    Console.ReadLine();
