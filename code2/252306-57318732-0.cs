    public static System.Collections.Generic.IEnumerable<T> ThrowOnNullOrEmpty<T>(this System.Collections.Generic.IEnumerable<T> source, string paramName = null)
    {
      using (var e = source.ThrowOnNull(paramName).GetEnumerator())
      {
        if (!e.MoveNext())
        {
          throw new System.ArgumentException(@"The sequence is empty.", paramName ?? nameof(source));
        }
        do
        {
          yield return e.Current;
        }
        while (e.MoveNext());
      }
    }
    var first = source.ThrowOnNullOrEmpty().First();
