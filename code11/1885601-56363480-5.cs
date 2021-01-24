       var result = count  
         .GroupBy(item => new {
            item.Item,
            item.FromWarehouse
            item.ToWarehouse 
          })
         .Select(chunk => new {
            key = chunk.Key,
            summary = chunk.Aggregate(
              Tuple.Create(0m, new List<Batch>()),
              (s, a) => Tuple.Create(s.Item1 + a.Quantity, 
                                     s.Item2.Concat(a.batchs).ToList())
          })
         .Select(item => new {
            Item = item.key.Item,
            FromWarehouse = item.key.FromWarehouse,
            ToWarehouse = item.key.ToWarehouse,
            Quantity = item.summary.Item1,
            Batches = item.summary.Item2
          }); // Add ToArray() if you want to materialize
