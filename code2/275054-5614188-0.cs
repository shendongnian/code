    Enqueue(item) { list.Add(item); }
    Dequeue() 
    { 
      if( !IsEmpty ) 
      {
        var item = list[0];
        list.Remove(item);
        return item;
      }
      return null;
    }
    IsFull{ get { return false; } }
    IsEmpty{ get { return list.Count == 0; }
