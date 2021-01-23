    public static IEnumerable<string> AddFuncCall(this IEnumerable<string> input)
    {
      foreach (string s in input)
      {
        yield return s;
        yield return "f(" + s + ")";
      }
    }
