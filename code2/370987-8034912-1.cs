    // extension method for supporting sorting
    public IEnumerable<Item> SortByPriority(this IEnumerable<Item> source)
    {
    	return source.OrderBy(x => x.Priority.Value).ThenByDescending(x => x.Priority.Updated);
    }
