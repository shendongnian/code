    Dictionary<string, List<string>> myList = new Dictionary<string, List<string>>();
    foreach (Item item in items)
    {
        if (myList[item.SomeKey] == null)
            myList.Add(item.SomeKey, new List<string>());
        myList[item.SomeKey].Add(item.SomeValue);
    } 
