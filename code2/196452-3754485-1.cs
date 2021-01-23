    public partial class MyObjectContext
    {
        ValidationContext ValidationContext { get; set; }
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
                    entity.Validate(entry, ValidationContext);
                });
        }
    }
    interface IValidatable
    {
        void Validate(ObjectStateEntry entry, ValidationContext context);
    }
    public enum ValidationContext
    {
        Admin,
        SomeOtherContext
    }
    public partial class MyEntity : IValidatable
    {
        public ValidationContext ValidationContext { get; set; }
    
        public void Validate(ObjectStateEntry entry, ValidationContext context)
        {
            // this validation doesn't apply to admins
            if (context != ValidationContext.Admin)
            {
                // validation logic here
            }
        }  
    }
