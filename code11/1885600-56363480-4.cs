       var result = count  
         .GroupBy(item => new {
            item.Item,
            item.FromWarehouse
            item.ToWarehouse 
          })
         .Select(chunk => new {
            key = chunk.Key,
            summary = chunk.Aggregate(
              Tuple.Create(0m, new List<Batch>()),                      // initial empty
              (s, a) => Tuple.Create(s.Item1 + a.Quantity,              // add
                                     s.Item2.Concat(a.batchs).ToList()) // merge
          })
