    var lines = File.ReadLines(path);
    var totals = lines.Select(line => line.Split('|'))
                      .Select(line => new { 
                          Item = line[0],
                          Count = Int32.Parse(line[1]) 
                      })
                      .GroupBy(x => x.Item)
                      .Select(g => new {
                          Item = g.Key,
                          Count = g.Sum(x => x.Count) 
                      });
    foreach (var total in totals) {
        Console.WriteLine("{0}|{1}", total.Item, total.Count);
    }
