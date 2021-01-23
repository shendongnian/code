    using (var enumerator = someCollection.GetEnumerator())
    {
      var last = !enumerator.MoveNext();
      T current;
      while(!last)
      {
        current = (T)(object)enumerator.Current;        
        //process item
        last = !enumerator.MoveNext();        
        //process item extension according to flag; flag means item
        
      }
    }
