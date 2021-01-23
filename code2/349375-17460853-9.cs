    using (var enumerator = collection.GetEnumerator())
    {
      var last = !enumerator.MoveNext();
      T current;
      while(!last)
      {
        current = enumerator.Current;        
        //process item
        last = !enumerator.MoveNext();        
        //process item extension according to flag; flag means item
        
      }
    }
