    IQueryable<Item> query = dataContext.Items;
    if (selectedText != "All")
    {
        query = query.Where(item => item.Type == selectedText);
    }
    List<Item> result = query.ToList();
