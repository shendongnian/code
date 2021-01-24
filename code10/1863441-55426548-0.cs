    var lines = File.ReadAllLines(@"right.txt")
                            .Select(x => x.Split(' ').Select(double.Parse).ToList())
                            .ToList();
    
    var h = lines.Count();
    var w = lines.Max(x => x.Count);
    var multiArray = new double[h, w];
    
    for (var i = 0; i < lines.Count; i++)
       for (var j = 0; j < lines[i].Count; i++)
          multiArray[i,j] = lines[i][j];
