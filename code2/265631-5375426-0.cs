    public void Swap2DRows(Array a, int indexOne, int indexTwo) {
      if (a == null} { throw new ArgumentNullException("a"); }
      if (a.Rank != 2) { throw new InvalidOperationException("..."); }
      // Only support zero based:
      if (a.GetLowerBound(0) != 0) { throw new InvalidOperationException("..."); }
      if (a.GetLowerBound(1) != 0) { throw new InvalidOperationException("..."); }
      if (indexOne >= a.GetUpperBound(0)) { throw new InvalidOperationException("..."); }
      if (indexTwo >= a.GetUpperBound(0)) { throw new InvalidOperationException("..."); }
      for (int i = 0; i <= a.GetUpperBound(1); ++i) {
        var t = a[indexOne, i];
        a[indexOne, i] = a[indexTwo, i];
        a[indexTwo, i] = t;
      }
    }
