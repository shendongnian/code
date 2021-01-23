    public override int SaveChanges()
    {
       DetectChanges();
       var modifiedEntities = ObjectStateManager.GetObjectStateEntries(EntityState.Modified);
       foreach(var entry in modifiedEntities)
       {
           var modifiedProps = ObjectStateManager.GetObjectStateEntry(entry).GetModifiedProperties();
           var currentValues = ObjectStateManager.GetObjectStateEntry(entry).CurrentValues;
           foreach(var propName in modifiedProps)
           {
               var newValue = currentValues[propName];
               //log changes
           }
       }
       return base.SaveChanges();
    }
