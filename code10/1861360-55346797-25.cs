        var loc =
       locationOutputDistinct
       .Select(x => x.Trim().Split(' ').ToArray()
       .Select(
           y => {
               var kv = y.Split(':');
               return new Res()
               {
                   Key = kv[0],
                   Val = int.Parse
                    (kv[1])
               };
           }).ToArray()).ToArray()
        .GroupBy(x =>
           String.Join(",",
           x.Select(y => y.Key))
           );
