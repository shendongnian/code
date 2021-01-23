    public List<Tuple<T, double>> Replace(List<Tuple<T, double>> collection, T term, double value) {
      return collection.Select(x => 
        Tuple.Create(
          x.Item1, 
          x.Item1.Equals(term) ? value : x.Item2)).ToList();
    }
