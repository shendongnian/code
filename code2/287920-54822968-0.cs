    context.BulkInsert(entitiesList);                 context.BulkInsertAsync(entitiesList);
    context.BulkUpdate(entitiesList);                 context.BulkUpdateAsync(entitiesList);
    context.BulkDelete(entitiesList);                 context.BulkDeleteAsync(entitiesList);
    context.BulkInsertOrUpdate(entitiesList);         context.BulkInsertOrUpdateAsync(entitiesList);         // Upsert
    context.BulkInsertOrUpdateOrDelete(entitiesList); context.BulkInsertOrUpdateOrDeleteAsync(entitiesList); // Sync
    context.BulkRead(entitiesList);                   context.BulkReadAsync(entitiesList);
