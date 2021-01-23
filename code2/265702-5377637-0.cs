    // Second choice: maybe it's not in the database yet, but it's awaiting insertion?
    inventoryItem = context.ObjectStateManager.GetObjectStateEntries(EntityState.Added)
        .Where(ose => ose.EntitySet == context.InventoryItems.EntitySet)
        .Select(ose => ose.Entity)
        .Cast<InventoryItem>()
        .Where(equalityPredicate.Compile())
        .SingleOrDefault();
    if (inventoryItem != null) {
        return inventoryItem;
    }
