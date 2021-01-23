    public List<Tuple<T, double>> Replace(List<Tuple<T, double>> collection, T term, double value) {
      return collection.
        Where(x => !x.Item1.Equals(term)).
        Append(Tuple.Create(term, value)).
        ToList();
    }
