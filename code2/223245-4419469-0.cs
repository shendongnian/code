    public partial class ModelContainer
    {
        partial void OnContextCreated()
        {
            this.SavingChanges +=
                (sender, e) => Validate(this.GetChangedEntities());
        }
        
        private IEnumerable<object> GetChangedEntities()
        {
            const EntityState AddedAndModified =
                EntityState.Added | EntityState.Modified;
        
            var entries = this.ObjectStateManager
                .GetObjectStateEntries(AddedAndModified);
            
            return entries.Where(e => e != null);
        }
        
        private static void Validate(IEnumerable<object> entities)
        {
            ValidationResults[] invalidResults = (
                from entity in entities
                let type = entity.GetType()
                let validator = ValidationFactory.CreateValidator(type)
                let results = validator.Validate(entity)
                where !results.IsValid
                select results).ToArray();
            if (invalidResults.Length > 0)
                throw new ValidationException(invalidResults);
        }    
    } 
