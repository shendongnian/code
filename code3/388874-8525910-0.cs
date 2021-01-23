    // Step 1.
    var record = context.MyTable.First();
    
    // Step 2.
    var foreignKey = ForeignKeyTable.Where(x => x.Id == record.ForeignKeyId).Single();
    
    // Step 3.
    var entry = context.Entry(record);
    
    // Step 4.
    trace(entry.Reference(x => x.ForeignKey).IsLoaded);
    
    // Step 5.
    trace(record.ForeignKey.SomeProperty);
