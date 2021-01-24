    using System.Data.Entity.Infrastructure;
    foreach (DbEntityEntry entry in context.ChangeTracker.Entries())
    {
        UpdateEntry(entry, userId);
    }  
