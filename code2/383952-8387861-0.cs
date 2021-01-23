    private void SetItems(IEnumerable<MyObject> _NewItems)
    {
        myCollection.Clear();
        foreach (MyObject newItem in _NewItems)
        {
            myCollection.Add(newItem);
        }
    }
