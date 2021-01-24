    public static Expression<Func<General, bool>> CreatePredicate(string columnName, object searchValue)
    {
        var xType = typeof(General);
        var x = Expression.Parameter(xType, "x");
        var column = xType.GetProperties().FirstOrDefault(p => p.Name == columnName);
    
        var body = column == null
            ? (Expression) Expression.Constant(true)
            : Expression.Equal(
                Expression.PropertyOrField(x, columnName),
                Expression.Constant(searchValue));
    
        return Expression.Lambda<Func<General, bool>>(body, x);
    }
    
    
    public IEnumerable<InventoryAsset> searchInventoryAssets(string query, string category, string market, string column)
    {
    	return	(from inventoryAsset in _context.InventoryAssets 
    		join marketCategory in _context.MarketCategories on inventoryAsset.MarketCategory_Identity equals marketCategory.Identity
    		join itemCategory in _context.ItemCategories on inventoryAsset.ItemCategory_Identity equals itemCategory.Identity
    		where CreatePredicate(column, query)).ToList()
    }
