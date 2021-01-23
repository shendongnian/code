    var list = new List<int>();
    for (int i = fromInclusive; i < toExclusive; i += step) {
        list.Add(i);
    }
    Parallel.ForEach(list, ...);
