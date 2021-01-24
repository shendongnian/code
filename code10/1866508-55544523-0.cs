    public static IEnumerable<TResult> OfType<TResult>(this IEnumerable source)
    {
       if (source == null) throw Error.ArgumentNull("source");
       return OfTypeIterator<TResult>(source);
    }
    
    static IEnumerable<TResult> OfTypeIterator<TResult>(IEnumerable source)
    {
       foreach (object obj in source)
       {
          if (obj is TResult) yield return (TResult)obj;
       }
    }
