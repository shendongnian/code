    public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      if(source == null)
        throw new ArgumentNullException("source");
      if(predicate == null)
        throw new ArgumentNullException("predicate");
      using(IEnumerator<TSource> en = source.GetEnumerator())
      {
        while(en.MoveNext())
        {
          TSource cur = en.Current;
          if(predicate(cur))
          {
            while(en.MoveNext())
              if(predicate(en.Current))
                throw new InvalidOperationException("Sequence contains more than one matching element");
           return cur;
          }
        }
      }
      throw new InvalidOperationException("Sequence contains no matching element");
    }
