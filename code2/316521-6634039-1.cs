    IQueryable<Item> query = db.Item;
    foreach (int tagid in tagFilterConditions)
    {
        int temp = tagid;
        query = query.Where(item =>
            db.Item_Tag.Exists(item_tag =>
                item_tag.ItemId = item.ItemId &&
                item_tag.TagId = temp
            )
        );
    }
