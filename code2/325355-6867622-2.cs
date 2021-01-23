    public Entities()
    {
        SavingChanges += new EventHandler(context_SavingChanges);
    }
    private void context_SavingChanges(object sender, EventArgs e)
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
