    public partial class ModelContainer
    {
        partial void OnContextCreated()
        {
            this.SavingChanges += new EventHandler(ModelContainer_SavingChanges);
        }
    
        void ModelContainer_SavingChanges(object sender, EventArgs e)
        {
            foreach (var item in this.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Added))
            {
                SetTransactionDescription(item);
            }
            foreach (var item in this.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Modified))
            {
                SetTransactionDescription(item);
            }
        }
    
        void SetTransactionDescription(System.Data.Objects.ObjectStateEntry entry)
        {
            Transaction transaction = entry.Entity as Transaction;
            if (transaction != null)
            {
                // Your code
            }
        }
    }
