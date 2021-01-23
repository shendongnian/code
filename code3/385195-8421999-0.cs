    from b in Billings
    group b by new { b.UserID, b.Type, Month = b.Date.Value.Month, b.Description } into groupItem
    select new 
    {
    	groupItem.Key.UserID,
    	groupItem.Key.Type,
    	groupItem.Key.Month,
    	groupItem.Key.Description,
    	Total = groupItem.Sum (b => b.Amount)
    }
