    using var enumerator = collection.GetEnumerator();
    var last = !enumerator.MoveNext();
    T current;
    while (!last)
    {
      current = enumerator.Current;        
      //process item
      last = !enumerator.MoveNext();        
      if(last)
      {
        //additional processing for last item
      }
    }
