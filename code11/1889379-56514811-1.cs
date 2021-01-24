    public async Task<ServiceResultWithoutBaseEntity<CategoryRollup>> Add(CategoryRollupViewModel newItem)
    {
        ...
        foreach(var categoryChildId in newItem.CategoryChildID)
        {
           var categoryRollupEntity = new CategoryRollup
           {
               CategoryParentID = newItem.CategoryParentID,
               CategoryChildID = categoryChildId
           }
           _context.CategoryRollups.Add(item);
        }
        await _context.SaveChangesAsync();
        ...
    }
