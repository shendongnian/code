    public static class IaExtensions
    {
        public static IEnumerable<Tuple<object, object>> GetAddedRelationships(
        this DbContext context)
        {
            return GetRelationships(context, EntityState.Added, (e, i) => e.CurrentValues[i]);
        }
        public static IEnumerable<Tuple<object, object>> GetDeletedRelationships(
        this DbContext context)
        {
            return GetRelationships(context, EntityState.Deleted, (e, i) => e.OriginalValues[i]);
        }
        private static IEnumerable<Tuple<object, object>> GetRelationships(
        this DbContext context,
        EntityState relationshipState,
        Func<ObjectStateEntry, int, object> getValue)
        {
            context.ChangeTracker.DetectChanges();
            var objectContext = ((IObjectContextAdapter)context).ObjectContext;
            return objectContext
            .ObjectStateManager
            .GetObjectStateEntries(relationshipState)
            .Where(e => e.IsRelationship)
            .Select(
                e => Tuple.Create(
                    objectContext.GetObjectByKey((EntityKey)getValue(e, 0)),
                    objectContext.GetObjectByKey((EntityKey)getValue(e, 1))));
        }
    }
