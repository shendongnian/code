    public static void RemoveWhere<T>(this IList<T> source, Func<T, bool> predicate)
    {
      //exceptions here...
      // how to use predicate here???
      for(int c = source.Count-1 ; c >= 0 ; c--)
      {
        if(predicate(source[c]))
        {
          source.RemoveAt(c);
        }
      }
    }
