    using (var enumerator = .GetEnumerator())
    {
      bool last;
      enumerator.MoveNext();
      T current;
      do
      {
        current = enumerator.Current;        
        //process item
        last = !enumerator.MoveNext();        
        //process item extension according to flag; flag means item
        
      } while (!flag);
    }
