    // Get the key field name & value.
    // This assumes your DbContext object is "_context", and that it is a single part key.
    var e = ((IObjectContextAdapter)_context).ObjectContext.ObjectStateManager.GetObjectStateEntry(validationErrors.Entry.Entity);
    string key = e.EntityKey.EntityKeyValues[0].Key;
    string val = e.EntityKey.EntityKeyValues[0].Value;
