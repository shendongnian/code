    Dictionary<int, List<B>> beegroups = bees.GroupBy(b => b.Anything1).ToDictionary(g => g.Key, g => g.ToList());
    foreach (A a in ayes) {
      List<B> group;
      if (beegroups.TryGetValue(a.Something1, out group)) {
        a.Something3 = group;
      }
    }
