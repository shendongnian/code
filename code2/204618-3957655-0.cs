    public void Initialize()
     {
      var item1 = new Item(); // no warning
      itemCollection.Add(item1);
    
      var item2 = CreateItem(); // CA2000 no longer appears
      Add(item2);
    
      var item3 = new Item(); // CA2000: call Dispose on object item3
      itemContainer.Add(item3);
     }
     private Item CreateItem()
     {
      return new Item();
     }
