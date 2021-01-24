    private static IEnumerable<TimeSpan[]> MyGrouping(IEnumerable<TimeSpan> source, 
                                                      double minutes = 5.0) {
      List<TimeSpan> list = new List<TimeSpan>();
      foreach (TimeSpan item in source.OrderBy(x => x)) {
        if (list.Any() && (item - list.Last()).TotalMinutes > minutes) {
          yield return list.ToArray();
          list.Clear();
        }
        list.Add(item);
      }
      if (list.Any())
        yield return list.ToArray();
    }
