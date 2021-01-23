    public static IEnumerable<T> FirstAndNeighbours<T>(
        this IEnumerable<T> source,
        Func<T,bool> predicate,
        int numOfElementsEitherSide)
    {
      using (var enumerator = source.GetEnumerator())
      {
        var previousItems = new Queue<T>(numOfElementsEitherSide);
        while(enumerator.MoveNext())
        {
          var current = enumerator.Current;
          if (predicate(current))
          {
            foreach (var previousItem in previousItems)
              yield return previousItem;
            yield return current;
            for (int i = 0; i < numOfElementsEitherSide; ++i)
            {
              if (!enumerator.MoveNext())
                yield break;
              yield return enumerator.Current;
            }
            yield break;
          }
          previousItems.Enqueue(current);
          if (previousItems.Count > numOfElementsEitherSide)
            previousItems.Dequeue();
        }
      }
    }
