    TableOperation insert = TableOperation.InsertOrReplace(entity);
    TableOperation delete = TableOperation.Delete(entity);
    TableOperation replace = TableOperation.Replace(entity);
    TableOperation merge = TableOperation.Merge(entity);
    ... etc
    await cloudTable.ExecuteAsync(insert);
    await cloudTable.ExecuteAsync(delete);
    await cloudTable.ExecuteAsync(replace);
    await cloudTable.ExecuteAsync(merge);
    ... etc
