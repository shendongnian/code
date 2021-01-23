    public partial class MyObjectContext
    {
        partial void OnContextCreated()
        {
            SavingChanges += new EventHandler(EntitySavingChanges);
        }
        private void EntitySavingChanges(object sender, EventArgs e)
        {
            ObjectStateManager
                .GetObjectStateEntries(EntityState.Added | EntityState.Modified | EntityState.Deleted)
                .Where(entry => entry.Entity is IValidatable).ToList().ForEach(entry =>
                {
                    var entity = entry.Entity as IValidatable;
                    entity.Validate(entry);
                });
        }
    }
    interface IValidatable
    {
        ValidationContext ValidationContext { get; set; }
        void Validate(ObjectStateEntry entry);
    }
    public enum ValidationContext
    {
        Admin,
        SomeOtherContext
    }
    public partial class MyEntity : IValidatable
    {
        public ValidationContext ValidationContext { get; set; }
    
        public void Validate(ObjectStateEntry entry)
        {
            // this validation doesn't apply to admins
            if (ValidationContext != ValidationContext.Admin)
            {
                // validation logic here
            }
        }  
    }
