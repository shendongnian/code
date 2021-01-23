    List<ItemClass> newList = new List<ItemClass>(originalList.Count);
    
    foreach(var item in originalList) {
        if (!item.ToBeRemoved) 
            newList.Add(item);
    }
    originalList = newList;
