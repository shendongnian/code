    public class AuditUpdateListener : IPostUpdateEventListener
    {
    	private const string _noValueString = "*No Value*";
    
    	private static string getStringValueFromStateArray(object[] stateArray, int position)
    	{
    		var value = stateArray[position];
    
    		return value == null || value.ToString() == string.Empty
    			    ? _noValueString
    			    : value.ToString();
    	}
    
    	public void OnPostUpdate(PostUpdateEvent @event)
    	{
    		if (@event.Entity is AuditLogEntry)
    		{
    			return;
    		}
    
    		var entityFullName = @event.Entity.GetType().FullName;
    
    		if (@event.OldState == null)
    		{
    			throw new ArgumentNullException("No old state available for entity type '" + entityFullName +
    				                            "'. Make sure you're loading it into Session before modifying and saving it.");
    		}
    
    		int[] dirtyFieldIndexes = @event.Persister.FindDirty(@event.State, @event.OldState, @event.Entity, @event.Session);
    
    		ISession session = @event.Session.GetSession(EntityMode.Poco);
    
    		string entityName = @event.Entity.GetType().Name;
    		string entityId = @event.Id.ToString();
    
    		foreach (int dirtyFieldIndex in dirtyFieldIndexes)
    		{
    			//For component types, check:
    			//	@event.Persister.PropertyTypes[dirtyFieldIndex] is ComponentType
    
    			var oldValue = getStringValueFromStateArray(@event.OldState, dirtyFieldIndex);
    			var newValue = getStringValueFromStateArray(@event.State, dirtyFieldIndex);
    
    			if (oldValue == newValue)
    			{
    				continue;
    			}
                    
                // Log
    			session.Save(new AuditLogEntry
    			                    {
    			                        EntityShortName = entityName,
    			                        FieldName = @event.Persister.PropertyNames[dirtyFieldIndex],
    			                        EntityFullName = entityFullName,
    			                        OldValue = oldValue,
    			                        NewValue = newValue,
    			                        Username = Environment.UserName,
    			                        EntityId = entityId,
    			                        AuditEntryType = AuditEntryType.PostUpdate
    			                    });
    		}
    
    		session.Flush();
    	}
    }
