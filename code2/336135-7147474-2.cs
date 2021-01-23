    public static IEnumerable<T> FirstAndNeighbours<T>(
      this IEnumerable<T> source,
      Func<T,bool> predicate,
      int numOfNeighboursEitherSide)
    {
      using (var enumerator = source.GetEnumerator())
      {
        var precedingNeighbours = new Queue<T>(numOfNeighboursEitherSide);
        while(enumerator.MoveNext())
        {
          var current = enumerator.Current;
          if (predicate(current))
          {
            //We have found the first matching element. First, we must return
            //the preceding neighbours.
            foreach (var precedingNeighbour in precedingNeighbours)
              yield return precedingNeighbour;
            //Next, return the matching element.
            yield return current;
            //Finally, return the succeeding neighbours.
            for (int i = 0; i < numOfNeighboursEitherSide; ++i)
            {
              if (!enumerator.MoveNext())
                yield break;
              yield return enumerator.Current;
            }
            yield break;
          }
          //No match yet, keep track of this preceding neighbour.
          if (precedingNeighbours.Count >= numOfNeighboursEitherSide)
            precedingNeighbours.Dequeue();
          precedingNeighbours.Enqueue(current);
        }
      }
    }
