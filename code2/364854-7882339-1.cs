    var myItems = new Dictionary<string, List<int>>();
    // ...
    if (myItems.ContainsKey(newItem.ItemData))
    {
        myItems[newItem.ItemData].Add(newItem.Row);
    }
    else
    {
        myItems.Add(newItem.ItemData, new List<int> { newItem.Row });
    }
  
