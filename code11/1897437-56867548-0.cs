    foreach (var item in items) 
    {
        string catName = GetCategoryByName(item.name);
        if (catName != null)
        {
            newItems.Add(new object
            {
                Name = item.name,
                Category = catName,
                AddedTime = DateTime.Now
            });
        }
    }
