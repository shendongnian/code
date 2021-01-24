    var data = File
      .ReadLines(@"C:\temp\Values.csv")
      .Where(line => !string.IsNullOrWhiteSpace(line)) // To be on the safe side
      .Skip(1)                                         // Skip title  
      .Select(line => line.Split(','))                  
      .Select(items => new {
         ID = long.Parse(items[0]), 
         Priority = int.Parse(items[1]), 
         Value = Decimal.Parse(items[2]),
       })
       .OrderBy(item => item.Value)                    // order by Value
       .GroupBy(item => item.Priority)                 // group by priority 
       .Select(group => string.Join(",", group         // turn group to comma separated
          .Select(item => string.Join(",", item.ID, item.Priority, item.Value))));
    
    File
      .WriteAllLines(@"C:\temp\sorted.csv", data);
