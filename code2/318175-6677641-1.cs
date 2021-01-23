    public partial class MyEntities
    {
        partial void OnContextCreated()
        {
            // Register the handler for the SavingChanges event.
            this.SavingChanges
                += new EventHandler(context_SavingChanges);
        }
    	
        // SavingChanges event handler.
        private static void context_SavingChanges(object sender, EventArgs e)
        {
            // Validate the state of each entity in the context
    		// before SaveChanges can succeed.
    		foreach (ObjectStateEntry entry in
    			((ObjectContext)sender).ObjectStateManager.GetObjectStateEntries(EntityState.Modified))
    		{
    			if (!entry.IsRelationship)
    			{
    				if (entry.Entity is IHasTimeStamp)
    				{
    					(entry.Entity as IHasTimeStamp).DoTimeStamp();
    				}
    			}
    		}
        }
    }
