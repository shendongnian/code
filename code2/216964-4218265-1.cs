    var lines = File.ReadLines(sourcePath);
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
    File.WriteAllLines(
        destinationPath,
        totals.Select(total => String.Format("{0}|{1}", total.Item, total.Count)
    );
