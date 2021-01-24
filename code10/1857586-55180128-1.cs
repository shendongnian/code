    public static async Task InitForceDelete(int ID, ProductContext context)
    {
        // wrap the recursion in a save so that it only happens once
        await ForceDeleteNoSave(ID, context);
        await context.SaveChangesAsync();
    }
    private static async Task ForceDeleteNoSave(int ID, ProductContext context)
    {
        var pd = await context.ProductDefinitions
                             .AsNoTracking()
                             .Include(x => x.ProductDefinitions)
                             .SingleAsync(x => x.ID == ID);
        if (pd.ProductDefinitions != null && pd.ProductDefinitions.Count != 0)
        {
            var childIDs = pd.ProductDefinitions.Select(x => x.ID).ToList();
            // delete the children recursively
            foreach (var child in childIDs)
            {
                await ForceDeleteNoSave(child, context);
            }
        }
        var supplier = await context.Suppliers.FindAsync(pd.SupplierID);
        supplier.Edited = true;
        // reload with tracking
        pd = await context.ProductDefinitions.FirstOrDefaultAsync(x => x.ID == ID);
        context.ProductDefinitions.Remove(pd);
    }
