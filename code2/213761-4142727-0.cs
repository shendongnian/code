    public static MyExt
    {
      public static IEnumerable<int> Range(int start, int end, Func<int, int> step)
      {
        //check parameters
        while (start <= end)
        {
            yield return start;
            start = step(start);
        }
      }
    }
