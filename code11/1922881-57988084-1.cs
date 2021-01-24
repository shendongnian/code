    var group = peopleList
      .GroupBy(x => new {
         Name = x.Item1,
         No   = x.Item2
       })
      .Select(chunk => new {
         Name = chunk.Key.Name,
         No   = chunk.Key.No,
         Sum  = chunk.Sum(item => item.Item3) 
       })
