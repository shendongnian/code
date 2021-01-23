    public static IEnumerable<int> SumSoFar(this IEnumerable<int> values)
    {
      int sumSoFar = 0;
      foreach (int value in values)
      {
        sumSoFar += value;
        yield return sumSoFar;
      }
    }
