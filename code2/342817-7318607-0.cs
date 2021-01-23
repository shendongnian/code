    List<Sample> samples = new List<Sample>(new[]
    {
        new Sample {Id = 1},
        new Sample {Id = 1},
        new Sample {Id = 2},
        new Sample {Id = 3},
        new Sample {Id = 1}
    });
    var duplicates = samples
        .Select    ((s, i) => new { s.Id, Index = i })  // Get item key and index
        .GroupBy   (s => s.Id)                          // Group by Key
        .Where     (g => g.Count() > 1)                 // Get duplicated ones
        .SelectMany(g => g.Skip (1)                     // We'll keep first one
                          .Select(i => i.Index))        // Get other items ids
        .Reverse();
    foreach (var index in duplicates)
    {
        samples.RemoveAt(index);
    }
