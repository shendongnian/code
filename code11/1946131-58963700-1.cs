    public static List<Item<T>> GetItemCounts<T>(List<T> input)
    {
        if (input == null) return null;
        var itemCounts = new List<Item<T>>();
        Item<T> currentItem = null;
        foreach (var item in input)
        {
            // If we haven't set an item yet, do so
            if (currentItem == null)
            {
                currentItem = new Item<T> {Value = item, Count = 1};
            }
            // If the current item is the same as this item, increment the count
            else if (currentItem.Value.Equals(item))
            {
                currentItem.Count++;
            }
            // This is a new item, so save the current item and create a new one
            else
            {
                itemCounts.Add(currentItem);
                currentItem = new Item<T> { Value = item, Count = 1 };
            }
        }
        // Add the last item
        if (currentItem != null) itemCounts.Add(currentItem);
        return itemCounts;
    }
