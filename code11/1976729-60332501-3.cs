    var letters = word.GroupBy(x => x)
                      .ToDictionary(x => x.Key, x => x.Count());
    
    if (letters.TryGetValue('a', out var aCount))
       Console.WriteLine($"The word contains a : {aCount}");
    
    if (letters.TryGetValue('a', out var bCount))
       Console.WriteLine($"The word contains b : {bCount}");
