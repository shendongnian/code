    public static void VisitLookAhead<TItem>(
      this IEnumerable<TItem> source,
      Action<IEnumerable<TItem>> visitor,
      int targetSize
      )
    {
      if (targetSize <= 1)
      {
        throw new Exception("invalid targetSize for VisitLookAhead");
      }
    
      List<List<TItem>> collections = new List<List<TItem>>();
      
    // after 6th iteration with targetSize 6
    //1, 2, 3, 4, 5, 6  <-- foundlist
    //2, 3, 4, 5, 6
    //3, 4, 5, 6
    //4, 5, 6
    //5, 6
    //6
      foreach(TItem x in source)
      {
        collections.Add(new List<TItem>());
        collections.ForEach(subList => subList.Add(x));
        List<TItem> foundList = collections
          .FirstOrDefault(subList => subList.Count == targetSize);
        if (foundList != null)
        {
          collections.Remove(foundList);
          visitor(foundList);
        }
      }
    
      //generate extra lists at the end - when lookahead will be missing items.
      foreach(int i in Enumerable.Range(1, targetSize)
      {
        collections.ForEach(subList => subList.Add(default(TItem)));
        List<TItem> foundList = collections
          .FirstOrDefault(subList => subList.Count == targetSize);
        if (foundList != null)
        {
          collections.Remove(foundList);
          visitor(foundList);
        }
      }
    }
