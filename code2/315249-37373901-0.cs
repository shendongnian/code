    private string GetTableName(DbEntityEntry ent)
    {
         return ObjectContext.GetObjectType(entry.Entity.GetType()).Name;
    }
    
