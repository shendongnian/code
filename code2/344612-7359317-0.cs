    var query = filteredList;
    if (!String.IsNullOrEmpty(id))
    {
        query = query.Where(c => c.ID.Contains(id))
    }
    if (!String.IsNullOrEmpty(name))
    {
        query = query.Where(c => c.Name.Contains(name))
    }
