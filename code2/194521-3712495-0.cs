    Dictionary<ItemType, Item> sum = new Dictionary<ItemType, Item>();
    foreach (var item in items)
    {
        Item currSum;
        if (sum.TryGetValue(item.Type, out currSum))
        {
            sum[item.Type] = (Item)item.GetType().GetInterfaces().Single(
                i => i.Name == "Item").GetMethod("Add")
            .Invoke(currSum, new object[] { item });
        }
        else
        {
            sum.Add(item.Type, item);
        }
    }
    List<Item> combined = sum.Values.ToList();
