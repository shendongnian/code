    public void OnPostUpdate(PostUpdateEvent updateEvent)
    {
    	if (updateEvent.Entity is AuditItem)
    		return;
    
    	var dirtyFieldIndexes = updateEvent.Persister.FindDirty(updateEvent.State, updateEvent.OldState, updateEvent.Entity, updateEvent.Session);
    
    	var data = new XElement("AuditedData");
    	
    	foreach (var dirtyFieldIndex in dirtyFieldIndexes)
    	{
    		var oldValue = GetStringValueFromStateArray(updateEvent.OldState, dirtyFieldIndex);
    		var newValue = GetStringValueFromStateArray(updateEvent.State, dirtyFieldIndex);
    
    		if (oldValue == newValue)
    		{
    			continue;
    		}
    
    		data.Add(new XElement("Item",
    							  new XAttribute("Property", updateEvent.Persister.PropertyNames[dirtyFieldIndex]),
    							  new XElement("OldValue", oldValue),
    							  new XElement("NewValue", newValue)
    							 ));
    	}
    
    	AuditService.Record(data, updateEvent.Entity, AuditType.Update);
    }
