    Object obj = new Object();
    private void Add1()
    { 
      lock(obj)
      {
        items.AddRange(C1.GetItems(p1, p2)); 
      }
    } 
    private void Add2() 
    { 
      lock(obj)
      {
        items.AddRange(C2.GetItems(p1, p2)); 
      }
    } 
