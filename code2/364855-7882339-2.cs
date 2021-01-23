    var myItems = new Dictionary<string, List<int>>();
    // ...
    if (myItems.ContainsKey(newItem.ItemData))
    {
        // myItems[newItem.ItemData] actually contains List<int> we created at some
        // point in the other part of if-else. 
        // The .Add method we call here belongs to List
        List<int> itemValues = myItems[newItem.ItemData];
        itemValues.Add(newItem.Row);
    }
    else
    {
        myItems.Add(newItem.ItemData, new List<int> { newItem.Row });
    }
