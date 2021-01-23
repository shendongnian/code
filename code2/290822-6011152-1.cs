    //tag duplicates for removal
    List<Item> toRemove = new List<Item>();
    foreach(Item item1 in listView.Items)
    {
      foreach(Item item2 in listView.Items)
      {
        //compare the two items
        if(item1.Tag == item2.Tag)
          toRemove.Add(item2);
      }
    }    
    
    //remove duplicates
    foreach(Item item in toRemove)
    {
      listView.Items.Remove(item);
    }
