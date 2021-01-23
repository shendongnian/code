    var missing = 
          Enumerable.Range(1, 200)
                   .Where(i => sequences.All(t => t.Item1 > i || t.Item2 < i));
    var overlapping = 
          Enumerable.Range(1, 200)
                    .Where(i => sequences.Count(t => t.Item1 <= i && t.Item2 >= i) > 1);
