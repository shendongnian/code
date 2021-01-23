     var results = methodList
                       .Select(l => l.Split(';'))
                       .GroupBy(a => a[0])
                       .Select(g => 
                           new 
                           {
                               Group = g.Key, 
                               Count = g.Count(),
                               Total = g.Sum(arr => Int32.Parse(arr[1])) 
                           });
     foreach(var result in results)
          Console.WriteLine("{0} {1} {2}", result.Group, result.Count, result.Total);
