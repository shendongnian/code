      var listA = new List<Something>();
      var listB = new List<Something>();
      var result = new List<Something>();
      var allPeriods = listA
        .SelectMany(st => new[] {
          new { AtTime = st.StartTime, A = 1, B = 0 },
          new { AtTime = st.EndTime, A = -1, B = 0} })
        .Concat(listB.SelectMany(st => new[]
        {
          new {AtTime = st.StartTime, A = 0, B = 1},
          new {AtTime = st.EndTime, A = 0, B = -1}
        }));
      var sorted = allPeriods.OrderBy(per => per.AtTime).ToList();
      var paired = sorted.Zip(sorted.Skip(1),
           (first, second) => new { Start = first, End = second });
      var a = 0;
      var b = 0;
      foreach(var pair in paired)
      {
        a += pair.Start.A;
        b += pair.Start.B;
        if (a > 0 && b == 0)
        {
          result.Add(new Something {
            StartTime = pair.Start.AtTime,
            EndTime = pair.End.AtTime });
        }
      }
