    public class MultiDataProvider : AuditDataProvider
    {
    	private AuditDataProvider[] _providers;
    	public MultiDataProvider(AuditDataProvider[] providers)
    	{
    		_providers = providers;
    	}
    	public override object InsertEvent(AuditEvent auditEvent)
    	{
    		object eventId = null;
    		foreach (var dp in _providers)
    		{
    			eventId = dp.InsertEvent(auditEvent);
    		}
    		return eventId;
    	}
    	public async override Task<object> InsertEventAsync(AuditEvent auditEvent)
    	{
    		object eventId = null;
    		foreach (var dp in _providers)
    		{
    			eventId = await dp.InsertEventAsync(auditEvent);
    		}
    		return eventId;
    	}
    	public override void ReplaceEvent(object eventId, AuditEvent auditEvent)
    	{
    		foreach (var dp in _providers)
    		{
    			dp.ReplaceEvent(eventId, auditEvent);
    		}
    	}
    	public async override Task ReplaceEventAsync(object eventId, AuditEvent auditEvent)
    	{
    		foreach (var dp in _providers)
    		{
    			await dp.ReplaceEventAsync(eventId, auditEvent);
    		}
    	}
    
    }
