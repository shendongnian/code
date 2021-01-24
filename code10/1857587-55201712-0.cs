    public static async Task ForceDelete(int ID, ProductContext context)
    {
    	var items = new List<ProductDefinition>();
    	// Collect the items by level    
    	var query = context.ProductDefinitions.Where(e => e.ID == ID);
    	while (true)
    	{
    		var nextLevel = await query
    			.Include(e => e.Supplier)
    			.ToListAsync();
    		if (nextLevel.Count == 0) break;
    		items.AddRange(nextLevel);
    		query = query.SelectMany(e => e.ProductDefinitions);
    	}
    
    	foreach (var item in items)
    		item.Supplier.Edited = true;
    
    	context.RemoveRange(items);
    
    	await context.SaveChangesAsync();
    }
