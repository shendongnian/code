    public List<row> GetSortedList(List<row> list, string[] sortOrder)
    {
        // argument-validation, including testing that 
        // sort-order has at least 1 item.
       
        return sortOrder.Skip(1)
                        .Aggregate(list.AsQueryable().OrderBy(sortOrder.First()),
                                   (query, nextSortTerm) => query.ThenBy(nextSortTerm))
                        .ToList();     
    }
