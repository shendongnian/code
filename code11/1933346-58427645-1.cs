    private static IEnumerable<TimeSpan[]> MyGrouping(IEnumerable<TimeSpan> source, 
                                                      double minutes = 5.0) {
      List<TimeSpan> list = new List<TimeSpan>();
      foreach (TimeSpan item in source.OrderBy(x => x)) {
        // shall we start a new group?
        if (list.Any() && (item - list.Last()).TotalMinutes > minutes) {
          // if yes, return the previous 
          yield return list.ToArray();
          
          list.Clear();
        }
        list.Add(item);
      }
      if (list.Any())
        yield return list.ToArray();
    }
