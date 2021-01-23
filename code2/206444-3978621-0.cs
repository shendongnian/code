    var result = list
        .GroupBy(
            x => x.Key,
            x => x.Value)
        .ToDictionary(
            g => g.Key,
            g => g.GroupBy(
                      y => y.Key,
                      y => y.Value)
                  .ToDictionary(
                      h => h.Key,
                      h => h.ToList()));
