    public static int RemoveAll<T>(this IList<T> list, Predicate<T> match)
    {
      if (match == null)
        throw new ArgumentNullException("match");
      int destIndex=0;
      int srcIndex;
      for(srcIndex=0;srcIndex<list.Count;srcIndex++)
      {
    	if(!match(list[srcIndex]))
    	{
    	  //if(srcIndex!=destIndex)//Small optimization, can be left out
    		list[destIndex]=list[srcIndex];
    	  destIndex++;
    	}
      }
      for(int removeIndex=list.Count-1;removeIndex>=destIndex;removeIndex--)
      {
        list.RemoveAt(removeIndex);
      }
      return srcIndex-destIndex;
    }
