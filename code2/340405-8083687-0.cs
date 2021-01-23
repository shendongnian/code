    object GetPrimaryKeyValue(DbEntityEntry entry)
    {
        var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
        return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
    }
