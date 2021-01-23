    private static List<MyData> cache = new List<MyData>();
    public IEnumerable<MyData> GetData() {
      foreach (var d in cache) {
        yield return d;
      }
      var position = cache.Count;
      while (maxItens < position) {
        MyData next = MakeNextItem(position);
        cache.Add(next);
        yield return next;
      }
    }
