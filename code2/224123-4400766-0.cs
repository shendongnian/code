    enum ItemType
    {
      First,
      Last,
      Normal
    }
    
    list.Foreach(T item, ItemType itemType) =>
    {
       if (itemType == ItemType.First)
       {
       }
    
       // rest of code
    };
