    var lines = File.ReadAllLines(@"d:\right.txt")
                      .Where(x => !string.IsNullOrWhiteSpace(x))
                      .Select(x => x.Split(new[]{' '},StringSplitOptions.RemoveEmptyEntries)
                                   .Select(double.Parse)
                                   .ToList())
                      .ToList();
    
    var h = lines.Count();
    var w = lines.Max(x => x.Count);
    var multiArray = new double[h, w];
    
    for (var i = 0; i < lines.Count; i++)
       for (var j = 0; j < lines[i].Count; j++)
          multiArray[i, j] = lines[i][j];
