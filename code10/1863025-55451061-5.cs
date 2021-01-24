    public Static IList<IList<InventoryItem>> ToSwappedLists(this List<List<InventoryItem>> source)
    {
        return new SwappedList<InventoryItem>
        {
            Source = source,
        }
    }
