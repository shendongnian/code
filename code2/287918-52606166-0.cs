    var context = new MyContext();
    context.Configuration.AutoDetectChangesEnabled = false;
    context.Configuration.ValidateOnSaveEnabled = false;
    context.BulkInsert(list);
    context.BulkSaveChanges();
