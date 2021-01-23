    // Get the id of the object we are saving
    PropertyInfo prop = GetProperty<TEntity>(entity, entity.EntityKey.EntityKeyValues[0].Key);
    string entityID = prop.GetValue(entity, null).ToString();
    
    // Get the current version of this object
    var originalEntity = GetEntity<TEntity>(PropertyEquals, entityID);
