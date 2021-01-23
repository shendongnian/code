    from Lists in dataContext.Todo_Lists
    where Lists.UserID == userID
    select new
    {
        ListID = Lists.ListID,
        ListName = Lists.ListName, 
        Items = dataContext.Todo_List_Items
                               .Where(i => Lists.ListID == i.ListId)
                               .Select(new {
                                                ItemID = Items.ItemID, 
                                                ItemName = Items.ItemName 
                                           }
    };
