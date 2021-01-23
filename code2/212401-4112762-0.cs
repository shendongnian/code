    public static IEnumerable<Entry> GetEntries(IEnumerable<int> list)
    {
      List<Entry> results = new List<Entry>();
      foreach (int i in list)
      {
        results.Add(new Entry() { Id = Guid.NewGuid().ToString("N"), Value = i });
      }
      return results;
    }
