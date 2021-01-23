    private async void LoadItems()
    {
        Task<List<MyItem>> getItemsTask = Task.Factory.StartNew(GetItems);
    
        foreach(MyItem item in await getItemsTask)
            MyCollection.Add(item);
    }
    private List<MyItem> GetItems()
    {
        // Make database call to get items
    }
