    public partial class AWEntities{ 
    partial void OnContextCreated()
    {
        this.SavingChanges += new EventHandler(context_SavingChanges);// Register the handler for the SavingChanges event.
    }
    private static void context_SavingChanges(object sender, EventArgs e)// SavingChanges event handler.
    {
        // Get all in Deleted state
        foreach (ObjectStateEntry entry in
            ((ObjectContext)sender).ObjectStateManager.GetObjectStateEntries(EntityState.Deleted))
        {
            if (entry.Entity.GetType() == typeof(MyType)))
            {
                // do what you want.
            }
        }
    }
    }
