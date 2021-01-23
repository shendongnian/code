    void RecursiveTest(List<Item> testingItems, Stack<Type> itemTypes, Stack<int> itemCounts)
    {
        if (itemTypes.Count == 0) { return; }
        Type thisType = itemTypes.Pop();
        int thisCount = itemCounts.Pop();
        List<Item> addedItems = new List<Item>();
        for (int i = 0; i <= thisCount; i++)
        {
            Item thisItem = (Item)Activator.CreateInstance(thisType); //Not sure
            testingItems.Add(thisItem);
            addedItems.Add(thisItem);
            DoTest(testingItems);
            RecursiveTest(testingItems, itemTypes, itemCounts);            
        }
        foreach(Item addedItem in addedItems)
        {
            testingItems.Remove(addedItem);
        }
        itemTypes.Push(thisType);
        itemCounts.Push(thisCount);
    }
