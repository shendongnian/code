    public ObjectContext Context(EntityObject entity) {
	    var relationshipManager = ((IEntityWithRelationships)entity).RelationshipManager;
        var wrappedOwnerProperty = relationshipManager.GetType().GetProperty("WrappedOwner",BindingFlags.Instance | BindingFlags.NonPublic);
        var wrappedOwner = wrappedOwnerProperty.GetValue(relationshipManager);
        var contextProperty = wrappedOwner.GetType().GetProperty("Context");
        return (ObjectContext)contextProperty.GetValue(wrappedOwner);
    }
