    private static double EditDistance<T>(IEnumerable<T> from,
                                          IEnumerable<T> to,
                                          Func<T, double> insertCost,
                                          Func<T, double> deleteCost,
                                          Func<T, T, double> editCost) {
      T[] source = from.ToArray();
      T[] target = to.ToArray();
      // Minimum cost so far
      double[][] D = Enumerable
        .Range(0, source.Length + 1)
        .Select(line => new double[target.Length + 1])
        .ToArray();
      // Edge: all removes
      double sum = 0.0;
      for (int i = 1; i <= source.Length; ++i)
        D[i][0] = (sum += deleteCost(source[i - 1]));
      // Edge: all inserts
      sum = 0.0;
      for (int i = 1; i <= target.Length; ++i)
        D[0][i] = (sum += insertCost(target[i - 1]));
      // Having fit N - 1, K - 1 characters let's fit N, K
      for (int i = 1; i <= source.Length; ++i)
        for (int j = 1; j <= target.Length; ++j) {
          // here we choose the operation with the least cost
          double insert = D[i][j - 1] + insertCost(target[j - 1]);
          double delete = D[i - 1][j] + deleteCost(source[i - 1]);
          double edit   = D[i - 1][j - 1] + editCost(source[i - 1], target[j - 1]);
          D[i][j] = Math.Min(Math.Min(insert, delete), edit);
        }
      return D[source.Length][target.Length];
    }
