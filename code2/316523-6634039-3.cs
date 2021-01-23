    // Query for all the items in the list
    int[] itemIds = itemList.Select(item => item.ItemId).AsArray();
    var query =
        db.Item.Where(item =>
            itemIds.Contains(item.ItemId));
    // Apply each tag condition
    foreach (int tagid in tagFilterConditions)
    {
        int temp = tagid;
        query = query.Where(item =>
            db.Item_Tag.Exists(item_tag =>
                item_tag.ItemId == item.ItemId && item_tag.TagId == temp)));
    }
