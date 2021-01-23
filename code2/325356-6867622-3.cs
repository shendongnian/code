    public partial class Entities
    {
        partial void OnContextCreated()
        {
            SavingChanges += OnSavingChanges;
        }
        void OnSavingChanges(object sender, EventArgs e)
        {
            var modifiedEntities = ObjectStateManager.GetObjectStateEntries(EntityState.Modified);
            foreach (var entry in modifiedEntities)
            {
                var modifiedProps = ObjectStateManager.GetObjectStateEntry(entry.EntityKey).GetModifiedProperties();
                var currentValues = ObjectStateManager.GetObjectStateEntry(entry.EntityKey).CurrentValues;
                foreach (var propName in modifiedProps)
                {
                    var newValue = currentValues[propName];
                    //log changes
                }
            }
        }
    }
