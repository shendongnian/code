    public static int RemoveAll<T>(this IList<T> list, Predicate<T> match)
    {
      int destIndex=0;
      for(int srcIndex=0;srcIndex<list.Count;srcIndex++)
      {
        if(match(list[srcIndex]))
        {
          if(srcIndex!=destIndex)//Small optimization, can be left out
            list[destIndex]=list[srcIndex];
          destIndex++;
        }
      }
    }
